using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;

namespace When2Watch.DAL.Database.Repositories
{
    class FriendRepository : IFriendRepository
    {
        private readonly ApplicationContext _context;

        public FriendRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FriendEntity>> GetAllAsync()
        {
            return await _context.Friends.ToListAsync();
        }

        public async Task<FriendEntity> GetByIdAsync(int id)
        {
            return await _context.Friends.FindAsync(id);
        }

        public async Task InsertAsync(FriendEntity friend)
        {
            await _context.Friends.AddAsync(friend);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FriendEntity friend)
        {
            _context.Entry(friend).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            FriendEntity friend = await _context.Friends.FindAsync(id);
            if (friend == null)
            {
                return;
            }
            await Task.Run(() => _context.Remove(friend));
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
