namespace Qdea.Back.Dtos
{
    public class UserStatusReadDto
    {
        public int UserStatusID { get; set; }
        public string Description { get; set; }
    }
    public class UserStatusCreateDto
    {
        public int UserStatusID { get; set; }
        public string Description { get; set; }
    }
    public class UserStatusUpdateDto
    {
        public int UserStatusID { get; set; }
        public string Description { get; set; }
    }
}