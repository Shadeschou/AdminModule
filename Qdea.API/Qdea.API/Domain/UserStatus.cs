using System.ComponentModel.DataAnnotations;

namespace Qdea.Back.Domain
{
    public class UserStatus
    {
        [Key]
        public int UserStatusID { get; set; }
        public string Description { get; set; }
    }
}