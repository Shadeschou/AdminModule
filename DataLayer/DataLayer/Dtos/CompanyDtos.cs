namespace DataLayer.Dtos
{
    public class CompanyReadDto
    {
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public string Label { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }//This might break EFCore.
    }
    public class CompanyCreateDto
    {
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public string Label { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }//This might break EFCore.
    }
    public class CompanyUpdateDto
    {
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public string Label { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }//This might break EFCore.
    }
}