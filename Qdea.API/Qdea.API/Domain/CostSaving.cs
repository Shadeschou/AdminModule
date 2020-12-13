using System;
using System.ComponentModel.DataAnnotations;

namespace Qdea.API.Domain
{
    public class CostSaving
    {
        [Key]
        public int CostSavingID { get; set; }
        public int IdeaID { get; set; }
        public string UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }
}