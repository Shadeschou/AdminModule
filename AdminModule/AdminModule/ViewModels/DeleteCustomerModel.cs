using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AdminModule.Services;

using DataLayer.Dtos;
using Microsoft.Extensions.DependencyInjection;

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

        public ObservableCollection<UserReadDto> Users { get; set;  }

        public IIntegrationService Api { get; set; }

        public DeleteCustomerModel()
        {
            
        }
        public DeleteCustomerModel(ServiceProvider serviceProvider)
        {
            Api = serviceProvider.GetService<IIntegrationService>();

            Users = new ObservableCollection<UserReadDto>();
            Users.Clear();
             testGetTable();

        }

        void testGetTable()
        {
            var entries = Api.GetTable<UserReadDto>("users");
            foreach (UserReadDto tag in entries)
            {
                Users.Add(tag);
            }

        }
    }
}