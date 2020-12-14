using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class AddedUser
    {
        [Key]
        public int AddedUserID { get; set; }

        public int? UserID { get; set; }
        public User User { get; set; }

        public int? IdeaID { get; set; }
        public Idea Idea { get; set; }
    }
}