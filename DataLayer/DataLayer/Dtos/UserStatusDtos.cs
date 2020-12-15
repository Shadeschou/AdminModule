namespace DataLayer.Dtos
{
    public class UserStatusReadDto : Dto
    {
        public int UserStatusID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return UserStatusID;
        }
    }
    public class UserStatusCreateDto : Dto
    {
        public int UserStatusID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return UserStatusID;
        }
    }
    public class UserStatusUpdateDto : Dto
    {
        public int UserStatusID { get; set; }
        public string Description { get; set; }

        public override int getPK()
        {
            return UserStatusID;
        }
    }
}