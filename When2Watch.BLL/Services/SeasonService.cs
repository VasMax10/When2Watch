using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;
using When2Watch.BLL.Interfaces;
using When2Watch.BLL.JsonPropertyAdds;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;
using When2Watch.DAL.Database.Repositories;

namespace When2Watch.BLL.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly IMapper _mapper;
        private readonly ISeasonRepository _repository;
        private readonly IEpisodeService _episodeService;

        private static readonly HttpClient _client = new HttpClient();

        public SeasonService(ApplicationContext context, IMapper mapper, IEpisodeService episodeService)
        {
            _repository = new SeasonRepository(context); 
            _mapper = mapper;
            _episodeService = episodeService;
        }

        public async Task CreateSeasonAsync(SeasonDTO season)
        {
            var newSeason = _mapper.Map<SeasonEntity>(season);
            await _repository.InsertAsync(newSeason);
            await _repository.SaveAsync();
            season.Id = newSeason.Id;
        }

        public Task DeleteSeasonAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SeasonDTO> GetSeasonAsync(int id)
        {
            var season = await _repository.GetByIdAsync(id);
            return _mapper.Map<SeasonDTO>(season);
        }

        public async Task<IEnumerable<SeasonDTO>> GetSeasonsBySeriesId(int seriesId)
        {
            var seasons = await _repository.GetAllAsync();
            return seasons
                .Where(s => s.SeriesId == seriesId)
                .Select(s => _mapper.Map<SeasonDTO>(s))
                .ToList();
        }

        public async Task ImportSeasonAsync(SeasonDTO season, int tmdbId)
        {
            var test = await GetSeasonsBySeriesId(season.SeriesId);
            if (test.Where(t => t.SeasonNumber == season.SeasonNumber).Count() == 0)
                await CreateSeasonAsync(season);
            else
                season.Id = test.Where(t => t.SeasonNumber == season.SeasonNumber)
                                .FirstOrDefault().Id;
            
            string uri = $"https://api.themoviedb.org/3/tv/{tmdbId}/season/{season.SeasonNumber}?api_key=fdbd71ab8b2b768e59653d40c256f41f";
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = _client.GetStreamAsync(uri);
            var results = await JsonSerializer.DeserializeAsync<EpisodesResults>(await streamTask);
            
            foreach (var item in results.Episodes)
            {
                EpisodeDTO episode = new EpisodeDTO
                {
                    Title = item.Name,
                    Description = item.Description,
                    EpisodeNumber = item.EpisodeNumber,
                    ReleaseDate = item.ReleaseDate,
                    SeasonId = season.Id
                };
                await _episodeService.CreateEpisodeAsync(episode);
            }
        }

        public Task UpdateSeasonAsync(SeasonDTO season)
        {
            throw new NotImplementedException();
        }
    }
}
