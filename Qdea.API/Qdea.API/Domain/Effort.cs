using System.ComponentModel.DataAnnotations;

namespace Qdea.Back.Domain
{
    public class Effort
    {
        [Key]
        public int EffortID { get; set; }
        public string Description { get; set; }
    }
}