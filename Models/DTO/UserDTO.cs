using System;
using UserApı.Models.Entity;

namespace UserApı.Models.DTO
{
    [Serializable]
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int StudentNumber { get; set; }
        public UserDTO()
        {

        }
        public UserDTO(User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.StudentNumber = user.StudentNumber;

        }
    }

}

