namespace DataLayer.Dtos
{
    public class IdeaStatusReadDto : Dto
    {
        public int IdeaStatusID { get; set; }
        public string Description { get; set; }
    }
    public class IdeaStatusCreateDto : Dto
    {
        public int IdeaStatusID { get; set; }
        public string Description { get; set; }
    }
    public class IdeaStatusUpdateDto : Dto
    {
        public int IdeaStatusID { get; set; }
        public string Description { get; set; }
    }
}