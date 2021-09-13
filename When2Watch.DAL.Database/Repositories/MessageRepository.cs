using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;

namespace When2Watch.DAL.Database.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationContext _context;
        public MessageRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MessageEntity>> GetAllAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<MessageEntity> GetByIdAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task InsertAsync(MessageEntity message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MessageEntity message)
        {
            _context.Entry(message).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            MessageEntity message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return;
            }
            await Task.Run(() => _context.Remove(message));
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
