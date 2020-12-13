using Qdea.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class UserIdea
    {
        [Key]
        public int UserIdeaID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
    }
}