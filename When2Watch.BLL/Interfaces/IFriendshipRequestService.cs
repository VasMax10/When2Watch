using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.BLL.Interfaces
{
    public interface IFriendshipRequestService
    {
        Task<IEnumerable<FriendshipRequestDTO>> GetFriendshipRequestsAsync(int userId);
        Task<FriendshipRequestDTO> GetFriendshipRequestAsync(int id);
        Task AcceptFriendshipRequestAsync(FriendshipRequestDTO request);
        Task RejectFriendshipRequestAsync(FriendshipRequestDTO request);
        Task CreateFriendshipRequestAsync(FriendshipRequestDTO request);
        Task UpdateFriendshipRequestAsync(FriendshipRequestDTO request);
        Task DeleteFriendshipRequestAsync(int id);
    }
}
;