namespace DataLayer.Dtos
{
    public class IdeaStatusReadDto : Dto
    {
        public int IdeaStatusID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return IdeaStatusID;
        }
    }
    public class IdeaStatusCreateDto : Dto
    {
        public int IdeaStatusID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return IdeaStatusID;
        }
    }
    public class IdeaStatusUpdateDto : Dto
    {
        public int IdeaStatusID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return IdeaStatusID;
        }
    }
}