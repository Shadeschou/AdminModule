namespace DataLayer.Dtos
{
    public class UserReadDto : Dto
    {
        public int UserID { get; set; }
        public int UserStatusID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserCreateDto : Dto
    {
        //public int UserID { get; set; }
        public int UserStatusID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserUpdateDto : Dto
    {
        public int UserID { get; set; }
        public int UserStatusID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}