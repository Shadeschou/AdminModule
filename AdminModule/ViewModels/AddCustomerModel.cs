using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModule.ViewModels
{
    public class AddCustomerModel : BaseViewModel
    {
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string Label { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
