using System;

namespace DataLayer.Dtos
{
    public class IdeaInteractionReadDto : Dto
    {
        public int IdeaInteractionID { get; set; }
        public int IdeaID { get; set; }
        public int IdeaInteractionTypeID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastDateTimeEdited { get; set; }

        public override int getPK()
        {
            return IdeaInteractionID;
        }
    }
    public class IdeaInteractionCreateDto : Dto
    {
        public int IdeaInteractionID { get; set; }
        public int IdeaID { get; set; }
        public int IdeaInteractionTypeID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastDateTimeEdited { get; set; }

        public override int getPK()
        {
            return IdeaInteractionID;
        }
    }
    public class IdeaInteractionUpdateDto : Dto
    {
        public int IdeaInteractionID { get; set; }
        public int IdeaID { get; set; }
        public int IdeaInteractionTypeID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastDateTimeEdited { get; set; }

        public override int getPK()
        {
            return IdeaInteractionID;
        }
    }
}