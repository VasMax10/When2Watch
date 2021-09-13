using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.BLL.Interfaces
{
    public interface ISeasonService
    {
        Task<IEnumerable<SeasonDTO>> GetSeasonsBySeriesId(int seriesId);
        Task<SeasonDTO> GetSeasonAsync(int id);
        Task CreateSeasonAsync(SeasonDTO season);
        Task ImportSeasonAsync(SeasonDTO season, int tmdbId);
        Task UpdateSeasonAsync(SeasonDTO season);
        Task DeleteSeasonAsync(int id);
    }
}
