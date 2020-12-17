using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class IdeaInteractionType
    {
        [Key] public int IdeaInteractionTypeID { get; set; }

        public string Description { get; set; }
        // here we can declare an idea interaction to be challenge, comment, costsaving or result
        // since theyre all structurally the same this is a better way to reduce redundancy
    }
}