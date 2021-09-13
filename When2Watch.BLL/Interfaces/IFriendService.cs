using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.BLL.Interfaces
{
    public interface IFriendService
    {
        Task<IEnumerable<FriendDTO>> GetUserFriendsAsync(int userId);
        Task GetFriendAsync(int id);
        Task CreateFriendAsync(FriendDTO friend);
        Task UpdateFriendAsync(FriendDTO friend);
        Task DeleteFriendAsync(int id);
    }
}
