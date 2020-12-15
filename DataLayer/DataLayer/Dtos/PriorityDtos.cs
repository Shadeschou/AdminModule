namespace DataLayer.Dtos
{
    public class PriorityReadDto : Dto
    {
        public int PriorityID { get; set; }
        public string Description { get; set; }
    }
    public class PriorityCreateDto : Dto
    {
        public int PriorityID { get; set; }
        public string Description { get; set; }
    }
    public class PriorityUpdateDto : Dto
    {
        public int PriorityID { get; set; }
        public string Description { get; set; }
    }
}