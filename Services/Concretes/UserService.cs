using System;
using UserApı.Models.DTO;
using UserApı.Models.Entity;
using UserApı.Repositories.Interfaces;
using UserApı.Services.Interfaces;

namespace UserApı.Services.Concretes
{
    public class UserService:IUserServices
    {
        private readonly IUserRepository _userRepositoy;

        public UserService(IUserRepository userRepositoy)
        {
            _userRepositoy = userRepositoy;
        }

        public async Task<User> AddUser(User user)
        {

            var result = await _userRepositoy.GetUserById(user.Id);
            if (result == null)
            {
                return await _userRepositoy.AddUser(user);
            }
            throw new InvalidOperationException("There is another user with the same name.");
        }

        public async Task<UserDTO> DeleteUser(int id)
        {
            try
            {
                User user = await _userRepositoy.DeleteUser(id);
                if (user != null)
                {
                    return new UserDTO(await _userRepositoy.DeleteUser(id));
                }
                return new UserDTO();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _userRepositoy.GetAllUser();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepositoy.GetUserById(id);
        }

        public async Task<UserDTO> UpdateUser(User user)
        {
            try
            {
                UserDTO userDTO = new UserDTO(await _userRepositoy.GetUserById(user.Id));
                if (userDTO != null)
                {
                    return new UserDTO(await _userRepositoy.UpdateUser(user));
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

