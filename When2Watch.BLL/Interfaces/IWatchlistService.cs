using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.BLL.Interfaces
{
    public interface IWatchlistService
    {
        Task<IEnumerable<WatchlistDTO>> GetAllAsync();
        Task<IEnumerable<WatchlistDTO>> GetWatchlistBySeriesUserAsync(int? seriesId, int? userId);
        Task CreateWatchlistAsync(WatchlistDTO watchlist);
        Task UpdateWatchlistAsync(WatchlistDTO watchlist);
        Task DeleteWatchlistAsync(int id);
    }
}
