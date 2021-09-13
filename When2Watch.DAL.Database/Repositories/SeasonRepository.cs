using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;

namespace When2Watch.DAL.Database.Repositories
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly ApplicationContext _context;

        public SeasonRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            SeasonEntity season = await _context.Seasons.FindAsync(id);
            if (season == null)
                return;
            await Task.Run(() => _context.Remove(season));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IEnumerable<SeasonEntity>> GetAllAsync()
        {
            return await _context.Seasons.ToListAsync();
        }

        public async Task<SeasonEntity> GetByIdAsync(int id)
        {
            return await _context.Seasons.FindAsync(id);
        }

        public async Task InsertAsync(SeasonEntity season)
        {
            await _context.Seasons.AddAsync(season);
            await _context.SaveChangesAsync();

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SeasonEntity season)
        {
            _context.Entry(season).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
