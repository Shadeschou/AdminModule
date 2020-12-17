using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class IdeaStatus
    {
        [Key] public int IdeaStatusID { get; set; }

        public string Description { get; set; }
    }
}