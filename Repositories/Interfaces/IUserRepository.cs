using System;
using UserApı.Models.Entity;

namespace UserApı.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
    }
}

