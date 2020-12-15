namespace DataLayer.Dtos
{
    public class PriorityReadDto : Dto
    {
        public int PriorityID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return PriorityID;
        }
    }
    public class PriorityCreateDto : Dto
    {
        public int PriorityID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return PriorityID;
        }
    }
    public class PriorityUpdateDto : Dto
    {
        public int PriorityID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return PriorityID;
        }
    }
}