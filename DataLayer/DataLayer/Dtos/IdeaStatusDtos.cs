namespace DataLayer.Dtos
{
    public class IdeaStatusReadDto
    {
        public int IdeaStatusID { get; set; }
        public string Description { get; set; }
    }
    public class IdeaStatusCreateDto
    {
        public int IdeaStatusID { get; set; }
        public string Description { get; set; }
    }
    public class IdeaStatusUpdateDto
    {
        public int IdeaStatusID { get; set; }
        public string Description { get; set; }
    }
}