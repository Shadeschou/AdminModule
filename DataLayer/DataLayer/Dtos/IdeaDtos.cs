using System;

namespace DataLayer.Dtos
{
    public class IdeaReadDto : Dto
    {
        public int IdeaID { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public int PriorityID { get; set; }
        public int IdeaStatusID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastEdited { get; set; }
    }
    public class IdeaCreateDto : Dto
    {
        public int IdeaID { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public int PriorityID { get; set; }
        public int IdeaStatusID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastEdited { get; set; }
    }
    public class IdeaUpdateDto : Dto
    {
        public int IdeaID { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public int PriorityID { get; set; }
        public int IdeaStatusID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastEdited { get; set; }
    }
}