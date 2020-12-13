using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }
        public string Title { get; set; }
    }
}