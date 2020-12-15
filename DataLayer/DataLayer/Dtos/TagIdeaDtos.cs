namespace DataLayer.Dtos
{
    public class TagIdeaReadDto : Dto
    {
        public int TagListID { get; set; }
        public int IdeaID { get; set; }
        public int TagID { get; set; }

        public override int getPK()
        {
            return TagListID;
        }
    }
    public class TagIdeaCreateDto : Dto
    {
        public int TagListID { get; set; }
        public int IdeaID { get; set; }
        public int TagID { get; set; }

        public override int getPK()
        {
            return TagListID;
        }
    }
    public class TagIdeaUpdateDto : Dto
    {
        public int TagListID { get; set; }
        public int IdeaID { get; set; }
        public int TagID { get; set; }

        public override int getPK()
        {
            return TagListID;
        }
    }
}