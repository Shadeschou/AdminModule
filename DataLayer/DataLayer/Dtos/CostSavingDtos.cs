using System;

namespace DataLayer.Dtos
{
    public class CostSavingReadDto
    {
        public int CostSavingID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }
    public class CostSavingCreateDto
    {
        public int CostSavingID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }
    public class CostSavingUpdateDto
    {
        public int CostSavingID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }
}