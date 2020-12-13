namespace DataLayer.Dtos
{
    public class UserIdeaReadDto
    {
        public int UserIdeaID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
    }
    public class UserIdeaCreateDto
    {
        public int UserIdeaID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
    }
    public class UserIdeaUpdateDto
    {
        public int UserIdeaID { get; set; }
        public int IdeaID { get; set; }
        public int UserID { get; set; }
    }
}