namespace DataLayer.Dtos
{
    public class AddedUserReadDto : Dto
    {
        public int AddedUserID { get; set; }
        public int UserID { get; set; }
        public int IdeaID { get; set; }

        public override int getPK()
        {
            return AddedUserID;
        }
    }

    public class AddedUserCreateDto : Dto
    {
        public int AddedUserID { get; set; }
        public int UserID { get; set; }
        public int IdeaID { get; set; }

        public override int getPK()
        {
            return AddedUserID;
        }
    }

    public class AddedUserUpdateDto : Dto
    {
        public int AddedUserID { get; set; }
        public int UserID { get; set; }
        public int IdeaID { get; set; }

        public override int getPK()
        {
            return AddedUserID;
        }
    }
}