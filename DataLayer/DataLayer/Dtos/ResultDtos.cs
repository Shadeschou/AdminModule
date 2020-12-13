using System;

namespace DataLayer.Dtos
{
    public class ResultReadDto
    {
        public int ResultID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }
    public class ResultCreateDto
    {
        public int ResultID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }
    public class ResultUpdateDto
    {
        public int ResultID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }
}