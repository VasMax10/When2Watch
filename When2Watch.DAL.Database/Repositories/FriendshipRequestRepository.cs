using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;

namespace When2Watch.DAL.Database.Repositories
{
    class FriendshipRequestRepository : IFriendshipRequestRepository
    {
        private readonly ApplicationContext _context;

        public FriendshipRequestRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FriendshipRequestEntity>> GetAllAsync()
        {
            return await _context.FriendshipRequests.ToListAsync();
        }

        public async Task<FriendshipRequestEntity> GetByIdAsync(int id)
        {
            return await _context.FriendshipRequests.FindAsync(id);
        }

        public async Task InsertAsync(FriendshipRequestEntity friendshipRequest)
        {
            await _context.FriendshipRequests.AddAsync(friendshipRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FriendshipRequestEntity friendshipRequest)
        {
            _context.Entry(friendshipRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            FriendshipRequestEntity friendshipRequest = await _context.FriendshipRequests.FindAsync(id);
            if (friendshipRequest == null)
            {
                return;
            }
            await Task.Run(() => _context.Remove(friendshipRequest));
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
