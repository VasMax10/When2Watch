using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetCommentsBySeriesAsync(int seriesId);
        Task<CommentDTO> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(CommentDTO comment);
        Task UpdateCommentAsync(CommentDTO comment);
        Task DeleteCommentAsync(int id);
    }
}
