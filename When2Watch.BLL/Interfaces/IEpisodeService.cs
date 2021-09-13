using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.BLL.Interfaces
{
    public interface IEpisodeService
    {
        Task<IEnumerable<EpisodeDTO>> GetEpisodesBySeasonAsync(int seriesId);
        Task<EpisodeDTO> GetEpisodeAsync(int id);
        Task CreateEpisodeAsync(EpisodeDTO episode);
        Task UpdateEpisodeAsync(EpisodeDTO episode);
        Task DeleteEpisodeAsync(int id);

    }
}
