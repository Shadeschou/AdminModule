namespace DataLayer.Dtos
{
    public class UserStatusReadDto : Dto
    {
        public int UserStatusID { get; set; }
        public string Description { get; set; }
    }
    public class UserStatusCreateDto : Dto
    {
        public int UserStatusID { get; set; }
        public string Description { get; set; }
    }
    public class UserStatusUpdateDto : Dto
    {
        public int UserStatusID { get; set; }
        public string Description { get; set; }
    }
}