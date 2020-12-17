using System.Windows.Input;
using AdminModule.Services;
using DataLayer.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace AdminModule.ViewModels
{
    internal class AddCustomerModel : BaseViewModel
    {


        #region Constructor

        public AddCustomerModel(ServiceProvider serviceProvider)
        {
            Api = serviceProvider.GetService<IIntegrationService>();

        }
    

        #endregion


        #region Properties

        private string passwordInput;

        public string PasswordInput
        {
            get => passwordInput;
            set
            {
                if (value != passwordInput)
                {
                    passwordInput = value;
                    OnPropertyChanged();
                }
            }
        }

        private string addressInput;

        public string AddressInput
        {
            get => addressInput;
            set
            {
                if (value != addressInput)
                {
                    addressInput = value;
                    OnPropertyChanged();
                }
            }
        }

        private int phoneNumberInput;

        public int PhoneNumberInput
        {
            get => phoneNumberInput;
            set
            {
                if (value != PhoneNumberInput)
                {
                    phoneNumberInput = value;
                    OnPropertyChanged();
                }
            }
        }

        public string emailInput;

        public string EmailInput
        {
            get => emailInput;
            set
            {
                if (value != EmailInput)
                {
                    emailInput = value;
                    OnPropertyChanged();
                }
            }
        }

        public string nameInput;

        public string NameInput
        {
            get => nameInput;

            set
            {
                if (value != nameInput)
                {
                    nameInput = value;
                    OnPropertyChanged();
                }
            }
        }
        public int statusInput;

        public int StatusInput
        {
            get => statusInput;

            set
            {
                if (value != statusInput)
                {
                    statusInput = value;
                    OnPropertyChanged();
                }
            }
        }

        public IIntegrationService Api { get; set; }

        #endregion


        #region Commands

        public ICommand InsertCommand => new BaseCommand(() =>
        {
            var userToBeInserted = new UserCreateDto
            {
                Address = AddressInput, Email = EmailInput, Name = NameInput, Password = PasswordInput,
                PhoneNumber = PhoneNumberInput,UserStatusID = StatusInput
            }; //NOT supplying primary key, db will auto increment itself
            var insertResponse = Api.Insert<UserCreateDto>("users", userToBeInserted);
            Clearfields();

        });

        public ICommand ClearAllFields => new BaseCommand(Clearfields
        );


        private void Clearfields()
        {
            AddressInput = " ";
            NameInput = " ";
            PhoneNumberInput = 0;
            EmailInput = " ";
            PasswordInput = " ";
            StatusInput = 0;


        }
        #endregion
    }
}