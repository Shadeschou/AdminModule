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

        private string passwordInput;
        public string PasswordInput {
            get => this.passwordInput;
            set
            {
                if (value != this.passwordInput)
                {
                    this.passwordInput = value;
                    OnPropertyChanged();
                }
            }

        }//Just for Convenience as this is part of the DB

        private string addressInput;
       public string AddressInput {
           get => this.addressInput;
           set
           {
               if (value != this.addressInput)
               {
                   this.addressInput = value;
                   OnPropertyChanged();
               }
           }

       }

        private int phoneNumberInput; 
       public int PhoneNumberInput
       {
           get => this.phoneNumberInput;
           set
           {
               if (value != this.PhoneNumberInput)
               {
                   phoneNumberInput = value;
                   OnPropertyChanged();
               }
            }
          
       }

       public string emailInput;
        public string EmailInput
       {
           get => this.emailInput;
           set
           {
               if (value != this.EmailInput)
               {
                   this.emailInput = value;
                   OnPropertyChanged();
               }
           }

       }

       public string nameInput;

       public string NameInput
       {
           get => this.nameInput;

           set
           {
               if (value != this.nameInput)
               {
                   this.nameInput = value;
                   OnPropertyChanged();
               }
            }
          
       }
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