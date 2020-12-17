using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class User
    {
        [Key] public int UserID { get; set; }

        public int? UserStatusID { get; set; }
        public UserStatus UserStatus { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}