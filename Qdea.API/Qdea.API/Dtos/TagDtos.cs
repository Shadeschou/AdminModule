namespace Qdea.Back.Dtos
{
    public class TagReadDto
    {
        public int TagID { get; set; }
        public string Title { get; set; }
    }
    public class TagCreateDto
    {
        public int TagID { get; set; }
        public string Title { get; set; }
    }
    public class TagUpdateDto
    {
        public int TagID { get; set; }
        public string Title { get; set; }
    }
}