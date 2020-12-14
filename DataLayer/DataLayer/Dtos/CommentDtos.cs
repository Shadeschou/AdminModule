using System;

namespace DataLayer.Dtos
{
    public class CommentReadDto
    {
        public int CommentID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
        public string TextContent { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }

    public class CommentCreateDto
    {
        public int CommentID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
        public string TextContent { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }

    public class CommentUpdateDto
    {
        public int CommentID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
        public string TextContent { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastDateTimeEdited { get; set; }
    }
}