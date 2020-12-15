namespace DataLayer.Dtos
{
    public class IdeaInteractionTypeReadDto : Dto
    {
        public int IdeaInteractionTypeID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return IdeaInteractionTypeID;
        }
    }
    public class IdeaInteractionTypeCreateDto : Dto
    {
        public int IdeaInteractionTypeID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return IdeaInteractionTypeID;
        }
    }
    public class IdeaInteractionTypeUpdateDto : Dto
    {
        public int IdeaInteractionTypeID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return IdeaInteractionTypeID;
        }
    }
}