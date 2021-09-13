using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using When2Watch.BLL.Interfaces;
using When2Watch.BLL.DTO;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;
using When2Watch.DAL.Database.Repositories;
using When2Watch.DAL.Database.Tools;
using System;

namespace When2Watch.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _repository;

        public CommentService(ApplicationContext context, IMapper mapper)
        {
            _repository = new CommentRepository(context);
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDTO>> GetAllAsync()
        {
            var comments = await _repository.GetAllAsync();
            return comments
                .Select(c => _mapper.Map<CommentDTO>(c))
                .ToList();
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsBySeriesAsync(int seriesId)
        {
            var comments = await _repository.GetAllAsync();
            return comments
                .Where(c => c.SeriesId == seriesId)
                .Select(c => _mapper.Map<CommentDTO>(c))
                .OrderBy(c => c.DateTime)
                .ToList();
        }
        public async Task CreateCommentAsync(CommentDTO comment)
        {
            comment.DateTime = DateTime.Now;
            var newComment = _mapper.Map<CommentEntity>(comment);
            await _repository.InsertAsync(newComment);
            await _repository.SaveAsync();
        }
        public async Task UpdateCommentAsync(CommentDTO comment)
        {
            var updatedComment = _mapper.Map<CommentEntity>(comment);
            await _repository.UpdateAsync(updatedComment);
            await _repository.SaveAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }

        public async Task<CommentDTO> GetCommentByIdAsync(int id)
        {
            var comment = await _repository.GetByIdAsync(id);
            return _mapper.Map<CommentDTO>(comment);
        }
    }
}
