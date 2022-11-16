using System;
using Microsoft.AspNetCore.Mvc;
using UserApı.Models.DTO;
using UserApı.Models.Entity;
using UserApı.Services.Interfaces;

namespace UserApı.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost("add")]
        public async Task<User> Add(User user)
        {
            await _userServices.AddUser(user);
            return user;
        }
        [HttpDelete("delete")]
        public async Task<UserDTO> Delete([FromQuery] int id)
        {
            return await _userServices.DeleteUser(id);

        }
        [HttpPut("update")]
        public async Task<UserDTO> UpdateUser([FromQuery] User user)
        {
            return await _userServices.UpdateUser(user);

        }

        [HttpGet("getall")]
        public async Task<List<User>> GetAll()
        {
            return await _userServices.GetAllUser();
        }
        [HttpGet("getbyuserid")]
        public async Task<User> GetByUserId([FromQuery] int id)
        {
            return await _userServices.GetUserById(id);
        }
    }
}

