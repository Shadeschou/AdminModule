namespace DataLayer.Dtos
{
    public class TagReadDto : Dto
    {
        public int TagID { get; set; }
        public string Title { get; set; }

        public override int getPK()
        {
            return TagID;
        }
    }
    public class TagCreateDto : Dto
    {
        public int TagID { get; set; }
        public string Title { get; set; }

        public override int getPK()
        {
            return TagID;
        }
    }
    public class TagUpdateDto : Dto
    {
        public int TagID { get; set; }
        public string Title { get; set; }

        public override int getPK()
        {
            return TagID;
        }
    }
}