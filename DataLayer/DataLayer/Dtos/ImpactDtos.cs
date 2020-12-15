namespace DataLayer.Dtos
{
    public class ImpactReadDto : Dto
    {
        public int ImpactID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return ImpactID;
        }
    }
    public class ImpactCreateDto : Dto
    {
        public int ImpactID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return ImpactID;
        }
    }
    public class ImpactUpdateDto : Dto
    {
        public int ImpactID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return ImpactID;
        }
    }
}