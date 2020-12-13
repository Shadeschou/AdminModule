namespace DataLayer.Dtos
{
    public class PriorityReadDto
    {
        public int PriorityID { get; set; }
        public string Description { get; set; }
    }
    public class PriorityCreateDto
    {
        public int PriorityID { get; set; }
        public string Description { get; set; }
    }
    public class PriorityUpdateDto
    {
        public int PriorityID { get; set; }
        public string Description { get; set; }
    }
}