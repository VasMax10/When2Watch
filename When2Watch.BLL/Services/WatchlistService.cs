using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;
using When2Watch.BLL.Interfaces;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Interfaces;
using When2Watch.DAL.Database.Repositories;

namespace When2Watch.BLL.Services
{
    class WatchlistService : IWatchlistService
    {
        private readonly IMapper _mapper;
        private readonly IWatchlistRepository _repository;
        public WatchlistService(ApplicationContext context, IMapper mapper)
        {
            _repository = new WatchlistRepository(context);
            _mapper = mapper;
        }
        public Task CreateWatchlistAsync(WatchlistDTO watchlist)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWatchlistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WatchlistDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WatchlistDTO>> GetWatchlistBySeriesUserAsync(int? seriesId, int? userId)
        {
            var watchlists = await _repository.GetAllAsync();
            var result = watchlists
                .Where(w => w.SeriesId == seriesId && w.UserId == userId).ToList();
            return (IEnumerable<WatchlistDTO>)result;
        }

        public Task UpdateWatchlistAsync(WatchlistDTO watchlist)
        {
            throw new NotImplementedException();
        }
    }
}
