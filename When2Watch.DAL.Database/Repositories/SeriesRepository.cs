using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;

namespace When2Watch.DAL.Database.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly ApplicationContext _context;
        public SeriesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SeriesEntity>> GetAllAsync()
        {
            return await _context.Series.ToListAsync();
        }

        public async Task<SeriesEntity> GetByIdAsync(int id)
        {
            return await _context.Series.FindAsync(id);
        }

        public async Task InsertAsync(SeriesEntity series)
        {
            await _context.Series.AddAsync(series);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SeriesEntity series)
        {
            _context.Entry(series).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            SeriesEntity series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return;
            }
            await Task.Run(() => _context.Remove(series));
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
