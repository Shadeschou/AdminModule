using Qdea.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class TagIdea
    {
        [Key]
        public int TagListID { get; set; }
        public int IdeaID { get; set; }
        public int TagID { get; set; }
    }
}