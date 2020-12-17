using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class Priority
    {
        [Key] public int PriorityID { get; set; }

        public string Description { get; set; }
    }
}