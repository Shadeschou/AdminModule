using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using AdminModule.Services;
using DataLayer.Dtos;
using Microsoft.Extensions.DependencyInjection;


namespace AdminModule.ViewModels
{
    internal class AddCustomerModel : BaseViewModel
    {


        #region public fields

        public string InputPassword;
        public string PasswordInput { get; set; } //Just for Convenience as this is part of the DB

       public string AddressInput { set; get; }

        public int PhoneNumberInput { get; set; }
        public string EmailInput { get; set; }
        public string NameInput { get; set; }
        public IIntegrationService Api { get; set; }
        
        #endregion
        #region private Fields
        #endregion


        #region Constructors



        public AddCustomerModel(ServiceProvider serviceProvider)
        {
            Api = serviceProvider.GetService<IIntegrationService>();
        }
        #endregion


        // This method MUST BE called by the Set accessor of each property for TwoWay binding to work.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        
        #region Commands
        public ICommand InsertCommand => new BaseCommand(() =>
       {

            //var tagToBeInserted = new TagCreateDto { Title = "adsfasdf" }; //NOT supplying primary key, db will auto increment itself
            //MessageBox.Show(tagToBeInserted.ToString())
            //var insertResponse = Api.Insert<TagCreateDto> ("tags", tagToBeInserted);
            //MessageBox.Show(insertResponse.ToString(), "too lazy to make this readable... but it worked!");


            var userToBeInserted = new UserCreateDto() { Address = AddressInput, Email = EmailInput, Name = NameInput, Password = PasswordInput, PhoneNumber = PhoneNumberInput }; //NOT supplying primary key, db will auto increment itself

            var insertResponse = Api.Insert<UserCreateDto>("users", userToBeInserted);

       });

        public ICommand ClearAllFields => new BaseCommand(() =>
        {
            this.AddressInput = " ";
            this.NameInput = " ";
            this.PhoneNumberInput = 0;
            this.EmailInput = " ";
            this.PasswordInput = " ";
        });

        #endregion
    }
}