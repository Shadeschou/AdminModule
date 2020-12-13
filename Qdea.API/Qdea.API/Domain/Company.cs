using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;


namespace Qdea.API.Domain
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public string Label { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }//This might break EFCore.
    }
}