namespace DataLayer.Dtos
{
    public class EffortReadDto : Dto
    {
        public int EffortID { get; set; }
        public string Description { get; set; }
    }

    public class EffortCreateDto : Dto
    {
        public int EffortID { get; set; }
        public string Description { get; set; }
    }

    public class EffortUpdateDto : Dto
    {
        public int EffortID { get; set; }
        public string Description { get; set; }
    }
}