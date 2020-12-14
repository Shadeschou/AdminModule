using System.ComponentModel.DataAnnotations;

namespace Qdea.Back.Domain
{
    public class Impact
    {
        [Key]
        public int ImpactID { get; set; }
        public string Description { get; set; }
    }
}