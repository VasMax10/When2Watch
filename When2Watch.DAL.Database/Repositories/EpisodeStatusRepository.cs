using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;

namespace When2Watch.DAL.Database.Repositories
{
    public class EpisodeStatusRepository : IEpisodeStatusRepository
    {
        private readonly ApplicationContext _context;
        public EpisodeStatusRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EpisodeStatusEntity>> GetAllAsync()
        {
            return await _context.EpisodeStatuses.ToListAsync();
        }

        public async Task<EpisodeStatusEntity> GetByIdAsync(int id)
        {
            return await _context.EpisodeStatuses.FindAsync(id);
        }

        public async Task InsertAsync(EpisodeStatusEntity episodeStatus)
        {
            await _context.EpisodeStatuses.AddAsync(episodeStatus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EpisodeStatusEntity episodeStatus)
        {
            _context.Entry(episodeStatus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            EpisodeStatusEntity episodeStatus = await _context.EpisodeStatuses.FindAsync(id);
            if (episodeStatus == null)
            {
                return;
            }
            await Task.Run(() => _context.Remove(episodeStatus));
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
