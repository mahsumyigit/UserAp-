using System;
using Microsoft.EntityFrameworkCore;
using UserApı.Models.Entity;
using UserApı.Repositories.Interfaces;

namespace UserApı.Repositories.Concretes
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextBase _context;

        public UserRepository(DbContextBase context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            User user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<User> UpdateUser(User user)
        {

            User userUpdate = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
            if (userUpdate != null)
            {
                userUpdate.Name = user.Name;
                userUpdate.Surname = user.Surname;
                userUpdate.StudentNumber = user.StudentNumber;

                await _context.SaveChangesAsync();
                return userUpdate;
            }
            return null;
        }
    }
}

