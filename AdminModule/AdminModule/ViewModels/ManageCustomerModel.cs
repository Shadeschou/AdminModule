using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AdminModule.Services;
using DataLayer.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace AdminModule.ViewModels
{
    internal class ManageCustomerModel : BaseViewModel
    {
        public UserReadDto selectedRecord;

        public ManageCustomerModel()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="serviceProvider"></param>
        public ManageCustomerModel(ServiceProvider serviceProvider)
        {
            Api = serviceProvider.GetService<IIntegrationService>();

            Users = new ObservableCollection<UserReadDto>();
            Users.Clear();
            GetTable();
          
        }

        public ObservableCollection<UserReadDto> Users { get; set; }
        public IIntegrationService Api { get; set; }

        public UserReadDto SelectedRecord
        {
            get => selectedRecord;

            set
            {
                if (value != selectedRecord)
                {
                    selectedRecord = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        ///     The Command  to change the Database Entries through the DataGrid.
        /// </summary>
        public ICommand ChangeEntry => new BaseCommand(() =>
        {
            var customer = SelectedRecord;
            var usersLocal = Api.GetTable<UserReadDto>("users");
            var userToBeUpdated = usersLocal.Find(x => x.UserID == SelectedRecord.UserID);
            if (userToBeUpdated == null) return;

            //and now update the title
            var updatingUser = new UserUpdateDto
            {
                Address = SelectedRecord.Address,
                Email = SelectedRecord.Email,
                Name = SelectedRecord.Name,
                Password = SelectedRecord.Password,
                PhoneNumber = SelectedRecord.PhoneNumber,
                UserID = SelectedRecord.UserID,
                UserStatusID = SelectedRecord.UserStatusID
            };
            //supplying primary key, so db knows which entry to update with rest of attributes
            var tagUpdateResponse = Api.Update("users", updatingUser);
            Users.Clear();
            GetTable();
        });

        public ICommand RefreshCommand => new BaseCommand(() =>
        {
            Users.Clear();
            GetTable();
        });
        private void GetTable()
        {
            var entries = Api.GetTable<UserReadDto>("users");
            foreach (var tag in entries) Users.Add(tag);
        }

    }
}