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
        private UserCreateDto userDto; 

        public AddCustomerModel()
        {

        }
       
        public AddCustomerModel(ServiceProvider serviceProvider)
        {
            Api = serviceProvider.GetService<IIntegrationService>();
        }

        public ICommand InsertCommand => new BaseCommand(() =>
        {
           
                var tagToBeInserted = new TagCreateDto { Title = "tAwesomeThoiasdasd asdcasdc" }; //NOT supplying primary key, db will auto increment itself
                var insertResponse = Api.Insert<TagCreateDto>("tags", tagToBeInserted);
                MessageBox.Show(insertResponse.ToString(), "too lazy to make this readable... but it worked!");


                //var userToBeInserted = new UserCreateDto() {Address = "AddressInput", Email = "EmailInput", Name = "NameInput",Password = "secret", PhoneNumber = 123123}; //NOT supplying primary key, db will auto increment itself
            // Api.Insert<UserCreateDto>("users", userToBeInserted);

        });

        public ICommand ClearAllFields => new BaseCommand(() =>
        {
            MessageBox.Show("ClearFirex");

            this.AddressInput = " ";
            this.NameInput = " ";
            this.PhoneNumberInput = 0;
            this.EmailInput = " ";
            this.PasswordInput = " ";
        });

    }
}