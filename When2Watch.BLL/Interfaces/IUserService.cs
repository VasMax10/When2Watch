using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> FindUsersAsync(string keyword);
        Task<UserDTO> GetUserAsync(int id);
        Task CreateUserAsync(IdentityUser user);
        Task UpdateUserAsync(UserDTO user);
        Task DeleteUserAsync(int id);
    }
}
