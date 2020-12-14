using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qdea.API.Domain
{
    public class Idea
    {
        [Key]
        public int IdeaID { get; set; }

        public int? UserID { get; set; }
        public User User { get; set; }

        public int? PriorityID { get; set; }
        public Priority Priority { get; set; }
        
        public int? IdeaStatusID { get; set; }
        public IdeaStatus IdeaStatus { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Impact { get; set; }
        public string Effort { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastEdited { get; set; }
    }
}