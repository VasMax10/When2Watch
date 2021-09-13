using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.BLL.Interfaces;
using When2Watch.BLL.DTO;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;
using When2Watch.DAL.Database.Repositories;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using System.Text.Json;
using When2Watch.DAL.Database.Tools;
using When2Watch.BLL.JsonPropertyAdds;

namespace When2Watch.BLL.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly IMapper _mapper;
        private readonly ISeriesRepository _repository;
        private readonly ISeasonService _seasonService;
        private static readonly HttpClient _client = new HttpClient();

        public SeriesService(ApplicationContext context, IMapper mapper, ISeasonService seasonService)
        {
            _repository = new SeriesRepository(context);
            _seasonService = seasonService;
            _mapper = mapper;
        }

        public async Task CreateSeriesAsync(SeriesDTO series)
        {
            series.LastSync = DateTime.Now;
            var test = await _repository.GetAllAsync();
            if (test.Where(t => t.TmdbId == series.TmdbId).FirstOrDefault() == null)
            {
                var newSeries = _mapper.Map<SeriesEntity>(series);
                await _repository.InsertAsync(newSeries);
                await _repository.SaveAsync();
            }
        }

        public async Task DeleteSeriesAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<SeriesDTO>> FindSeriesAsync(string keyword)
        {
            string uri = $"https://api.themoviedb.org/3/search/tv?api_key=fdbd71ab8b2b768e59653d40c256f41f&language=en-US&page=1&query={keyword}&include_adult=false";
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = _client.GetStreamAsync(uri);
            TVSeries results = await JsonSerializer.DeserializeAsync<TVSeries>(await streamTask);
            List<SeriesDTO> series = new List<SeriesDTO>();
            foreach (var item in results.Results)
            {
                SeriesDTO newSeries = new SeriesDTO
                {
                    Title = item.Title,
                    Description = item.Description,
                    PosterPath = item.PosterPath,
                    RatingIMDb = item.RatingImdb,
                    TmdbId = item.TmdbId
                };
                series.Add(newSeries);
            }
            return series;
        }

        public async Task<IEnumerable<SeriesDTO>> GetAllAsync()
        {
            var series = await _repository.GetAllAsync();
            return series
                .Select(s => _mapper.Map<SeriesDTO>(s))
                .ToList();
        }
        
        public async Task<SeriesDTO> GetSeriesAsync(int id)
        {
            var series = await _repository.GetByIdAsync(id);
            return _mapper.Map<SeriesDTO>(series);
        }

        public async Task UpdateSeriesAsync(SeriesDTO series)
        {
            var updatedSeries = _mapper.Map<SeriesEntity>(series);
            await _repository.UpdateAsync(updatedSeries);
            await _repository.SaveAsync();
        }

        public async Task<SeriesDTO> GetSeriesbyTmdbAsync(int TmdbId)
        {
            IEnumerable<SeriesEntity> series = await _repository.GetAllAsync();
            return series
                .Where(s => s.TmdbId == TmdbId)
                .Select(s => _mapper.Map<SeriesDTO>(s))
                .FirstOrDefault();
        }

        public async Task ImportSeriesAsync(SeriesDTO series)
        {
            var newSeries = await GetSeriesbyTmdbAsync(series.TmdbId);
            if (newSeries == null)
            {
                await CreateSeriesAsync(series);
                newSeries = await GetSeriesbyTmdbAsync(series.TmdbId);
            }
            string uri = $"https://api.themoviedb.org/3/tv/{series.TmdbId}?api_key=fdbd71ab8b2b768e59653d40c256f41f";
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = _client.GetStreamAsync(uri);
            var results = await JsonSerializer.DeserializeAsync<SeasonsResults>(await streamTask);
            
            foreach (var item in results.Seasons)
            {
                SeasonDTO season = new SeasonDTO
                {
                    Name = item.Name,
                    SeasonNumber = item.Number,
                    Description = item.Description,
                    SeriesId = newSeries.Id
                };
                await _seasonService.ImportSeasonAsync(season, newSeries.TmdbId);
            }
        }
    }
}
