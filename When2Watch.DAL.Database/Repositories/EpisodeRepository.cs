using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;

namespace When2Watch.DAL.Database.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly ApplicationContext _context;
        public EpisodeRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EpisodeEntity>> GetAllAsync()
        {
            return await _context.Episodes.ToListAsync();
        }

        public async Task<EpisodeEntity> GetByIdAsync(int id)
        {
            return await _context.Episodes.FindAsync(id);
        }

        public async Task InsertAsync(EpisodeEntity episode)
        {
            await _context.Episodes.AddAsync(episode);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EpisodeEntity episode)
        {
            _context.Entry(episode).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            EpisodeEntity episode = await _context.Episodes.FindAsync(id);
            if (episode == null)
            {
                return;
            }
            await Task.Run(() => _context.Remove(episode));
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
