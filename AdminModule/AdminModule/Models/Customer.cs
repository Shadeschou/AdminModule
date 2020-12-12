namespace AdminModule.Models
{
    public class Customer
    {
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string Label { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; } //This might break EFCore.
    }
}