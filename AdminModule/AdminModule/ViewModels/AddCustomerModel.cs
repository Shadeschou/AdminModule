using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AdminModule.Services;
using AdminModule.utility;
using AdminModule.Views;
using DataLayer.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;


namespace AdminModule.ViewModels
{
    public class AddCustomerModel : BaseViewModel
    {
        public int UserIDInput { get; set; } // PK
        public string PasswordInput { get; set; } //Just for Convenience as this is part of the DB
        public string AddressInput{ get; set; }
        public int PhoneNumberInput { get; set; }
        public string EmailInput { get; set; }
        public int UserStatusIDInput { get; set; } //FK
        public string NameInput { get; set; }

        public IIntegrationService Api { get; set; }

        public AddCustomerModel()
        {
            this.AddressInput = "Enter Address";
            this.NameInput = " Enter Name";
            this.PhoneNumberInput = 128;
            this.EmailInput = " Enter Mail ";
            this.PasswordInput = "Enter PW ";
        }
       
        public AddCustomerModel(ServiceProvider serviceProvider)
        {
            Api = serviceProvider.GetService<IIntegrationService>();
        }

        public ICommand InsertCommand => new BaseCommand(() =>
        {
            var userToBeInserted = new UserCreateDto() { Name = "Name", Address = "Nice", Email = "NiceMail",Password = "NicePW", PhoneNumber = 1123123}; //NOT supplying primary key, db will auto increment itself
            var insertResponse = Api.Insert<UserCreateDto>("tags", userToBeInserted);

        });


    }
}