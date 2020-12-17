namespace DataLayer.Dtos
{
    public class TagReadDto : Dto
    {
        public int TagID { get; set; }
        public string Title { get; set; }
    }

    public class TagCreateDto : Dto
    {
        public int TagID { get; set; }
        public string Title { get; set; }
    }

    public class TagUpdateDto : Dto
    {
        public int TagID { get; set; }
        public string Title { get; set; }
    }
}