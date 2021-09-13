using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.BLL.Interfaces
{
    public interface IEpisodeStatusService
    {
        Task<EpisodeStatusDTO> GetEpisodeStatusAsync();
        Task CreateEpisodeStatusAsync(EpisodeStatusDTO episodeStatus);
        Task UpdateEpisodeStatusAsync(EpisodeStatusDTO episodeStatus);
        Task DeleteEpisodeStatusAsync(int id);

    }
}
