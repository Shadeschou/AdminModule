using System.ComponentModel.DataAnnotations;
using System;

namespace Qdea.API.Domain
{
    public class Idea
    {
        [Key]
        public int IdeaID { get; set; }        
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string PriorityID { get; set; }
        public string IdeaStatusID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastEdited { get; set; }

    }
}