using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.BLL.Interfaces
{
    public interface ISeriesService
    {
        Task<IEnumerable<SeriesDTO>> GetAllAsync();
        Task<SeriesDTO> GetSeriesAsync(int id);
        Task<SeriesDTO> GetSeriesbyTmdbAsync(int TmdbId);
        //Task CreateSeriesAsync(SeriesDTO series);
        Task ImportSeriesAsync(SeriesDTO series);
        Task UpdateSeriesAsync(SeriesDTO series);
        Task DeleteSeriesAsync(int id);
        Task<IEnumerable<SeriesDTO>> FindSeriesAsync(string keyword);
    }
}
