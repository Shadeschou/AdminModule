namespace DataLayer.Dtos
{
    public class AddedUserReadDto : Dto
    {
        public int AddedUserID { get; set; }
        public int UserID { get; set; }
        public int IdeaID { get; set; }
    }

    public class AddedUserCreateDto : Dto
    {
        public int AddedUserID { get; set; }
        public int UserID { get; set; }
        public int IdeaID { get; set; }
    }

    public class AddedUserUpdateDto : Dto
    {
        public int AddedUserID { get; set; }
        public int UserID { get; set; }
        public int IdeaID { get; set; }
    }
}