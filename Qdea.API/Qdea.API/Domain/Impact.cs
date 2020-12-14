using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class Impact
    {
        [Key]
        public int ImpactID { get; set; }
        public string Description { get; set; }
    }
}