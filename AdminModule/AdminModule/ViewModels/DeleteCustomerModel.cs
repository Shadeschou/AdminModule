using System.Collections.ObjectModel;
using System.Configuration;
using System.Security.RightsManagement;

namespace AdminModule.ViewModels
{
    public class DeleteCustomerModel : BaseViewModel
    {
        public int UserIDInput { get; set; } // PK
        public string PasswordInput { get; set; } //Just for Convenience as this is part of the DB
        public string AddressInput { get; set; }
        public int PhoneNumberInput { get; set; }
        public string EmailInput { get; set; }
        public int UserStatusIDInput { get; set; } //FK
        public string NameInput { get; set; }

        public ObservableCollection<string> Users { get; set;  }

    }
}