namespace DataLayer.Dtos
{
    public class ImpactReadDto : Dto
    {
        public int ImpactID { get; set; }
        public string Description { get; set; }
    }
    public class ImpactCreateDto : Dto
    {
        public int ImpactID { get; set; }
        public string Description { get; set; }
    }
    public class ImpactUpdateDto : Dto
    {
        public int ImpactID { get; set; }
        public string Description { get; set; }
    }
}