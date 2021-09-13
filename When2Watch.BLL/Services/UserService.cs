using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;
using When2Watch.BLL.Interfaces;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Entities;
using When2Watch.DAL.Database.Interfaces;
using When2Watch.DAL.Database.Repositories;
using Microsoft.AspNetCore.Identity;

namespace When2Watch.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        public UserService(ApplicationContext context, IMapper mapper)
        {
            _repository = new UserRepository(context); ;
            _mapper = mapper;
        }
        public async Task CreateUserAsync(IdentityUser user)
        {
            UserDTO userDTO = new UserDTO
            {
                Name = user.UserName,
                Email = user.Email,
                Searchable = true,
                Avatar = ""
            };
            var newUser = _mapper.Map<UserEntity>(userDTO);
            await _repository.InsertAsync(newUser);
            await _repository.SaveAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<UserDTO>> FindUsersAsync(string keyword)
        {
            var users = await _repository.GetAllAsync();
            return users
                .Where(u => u.Name.Contains(keyword))
                .Select(u => _mapper.Map<UserDTO>(u))
                .ToList();
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public Task UpdateUserAsync(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
