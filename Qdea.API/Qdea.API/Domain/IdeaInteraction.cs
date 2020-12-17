using System;
using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class IdeaInteraction
    {
        [Key] public int IdeaInteractionID { get; set; }

        public int? IdeaID { get; set; }
        public Idea Idea { get; set; }

        public int? IdeaInteractionTypeID { get; set; }
        public IdeaInteractionType IdeaInteractionType { get; set; }

        public int? UserID { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }
}