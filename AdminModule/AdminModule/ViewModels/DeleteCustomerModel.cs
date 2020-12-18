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

        public UserReadDto selectedRecord;

        public UserReadDto SelectedRecord
        {
            get => this.selectedRecord;

            set
            {
                if (value != this.selectedRecord)
                {
                    this.selectedRecord = value;
                    OnPropertyChanged();
                }
            }

        }
        public ObservableCollection<UserReadDto> Users { get; set;  }

        public IIntegrationService Api { get; set; }


        public ICommand DeleteEntry => new BaseCommand(() =>
        {
            UserReadDto customer = (UserReadDto)SelectedRecord;
            var userCollectionLocal = Api.GetTable<UserReadDto>("users");
            int tagId = 0;
            foreach (UserReadDto users in userCollectionLocal)
            {
                if (users.UserID > tagId) tagId = users.UserID;
            }
            if (tagId < 0) return;

            //and now delete it
            var tagDeletionResponseMessage = Api.Delete("users", SelectedRecord.UserID);
            Users.Remove(selectedRecord);
            Users.Clear();
            testGetTable();
        });

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