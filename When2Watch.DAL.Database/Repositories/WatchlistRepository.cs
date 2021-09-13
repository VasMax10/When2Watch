using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;

namespace When2Watch.DAL.Database.Repositories
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly ApplicationContext _context;
        public WatchlistRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WatchlistEntity>> GetAllAsync()
        {
            return await _context.Watchlists.ToListAsync();
        }

        public async Task<WatchlistEntity> GetByIdAsync(int id)
        {
            return await _context.Watchlists.FindAsync(id);
        }

        public async Task InsertAsync(WatchlistEntity watchlist)
        {
            await _context.Watchlists.AddAsync(watchlist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WatchlistEntity watchlist)
        {
            _context.Entry(watchlist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            WatchlistEntity watchlist = await _context.Watchlists.FindAsync(id);
            if (watchlist == null)
            {
                return;
            }
            await Task.Run(() => _context.Remove(watchlist));
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
