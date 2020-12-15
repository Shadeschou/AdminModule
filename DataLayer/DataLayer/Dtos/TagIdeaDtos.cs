namespace DataLayer.Dtos
{
    public class TagIdeaReadDto : Dto
    {
        public int TagListID { get; set; }
        public int IdeaID { get; set; }
        public int TagID { get; set; }
    }
    public class TagIdeaCreateDto : Dto
    {
        public int TagListID { get; set; }
        public int IdeaID { get; set; }
        public int TagID { get; set; }
    }
    public class TagIdeaUpdateDto : Dto
    {
        public int TagListID { get; set; }
        public int IdeaID { get; set; }
        public int TagID { get; set; }
    }
}