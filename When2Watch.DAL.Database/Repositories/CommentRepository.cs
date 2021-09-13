using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;

namespace When2Watch.DAL.Database.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationContext _context;
        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<CommentEntity>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<CommentEntity> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task InsertAsync(CommentEntity comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CommentEntity comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            CommentEntity comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return;
            }
            await Task.Run(() => _context.Remove(comment));
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
