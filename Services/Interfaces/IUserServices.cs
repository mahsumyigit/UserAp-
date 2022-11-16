using System;
using UserApı.Models.DTO;
using UserApı.Models.Entity;

namespace UserApı.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<UserDTO> UpdateUser(User user);
        Task<UserDTO> DeleteUser(int id);
    }
}

