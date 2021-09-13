using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;
using When2Watch.BLL.Interfaces;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;
using When2Watch.DAL.Database.Repositories;

namespace When2Watch.BLL.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IMapper _mapper;
        private readonly IEpisodeRepository _repository;
        public EpisodeService(ApplicationContext context, IMapper mapper)
        {
            _repository = new EpisodeRepository(context);
            _mapper = mapper;
        }

        public async Task CreateEpisodeAsync(EpisodeDTO episode)
        {
            var test = await GetEpisodesBySeasonAsync(episode.SeasonId);
            if (test.Where(t => t.EpisodeNumber == episode.EpisodeNumber).Count() > 0)
                return;
            var newEpisode = _mapper.Map<EpisodeEntity>(episode);
            await _repository.InsertAsync(newEpisode);
            await _repository.SaveAsync();
        }

        public Task DeleteEpisodeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EpisodeDTO> GetEpisodeAsync(int id)
        {
            var episode = await _repository.GetByIdAsync(id);
            return _mapper.Map<EpisodeDTO>(episode);
        }

        public async Task<IEnumerable<EpisodeDTO>> GetEpisodesBySeasonAsync(int seasonId)
        {
            var episodes = await _repository.GetAllAsync();
            return episodes
                .Where(e => e.SeasonId == seasonId)
                .Select(e => _mapper.Map<EpisodeDTO>(e))
                .ToList();
        }

        public Task UpdateEpisodeAsync(EpisodeDTO episode)
        {
            throw new NotImplementedException();
        }
    }
}
