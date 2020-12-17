using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Windows.Input;
using System.Windows.Markup;
using AdminModule.Services;
using DataLayer.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace AdminModule.ViewModels
{
    internal class ManageCustomerModel : BaseViewModel
    {

        public int UserIDInput { get; set; } // PK
        public string PasswordInput { get; set; } //Just for Convenience as this is part of the DB
        public string AddressInput { get; set; }
        public int PhoneNumberInput { get; set; }
        public string EmailInput { get; set; }
        public int UserStatusIDInput { get; set; } //FK
        public string NameInput { get; set; }

        //clsItemsBL objItem = new clsItemBL();
        //dgItemSearch.ItemsSource = objItem.GetAllItems();
        //Than in the code of the form where you DataGrid is you can do tha casting like this (usually this is done in the selected item changed for that DataGrid).  This way than you can acces each property of the selected item in the DataGrid.

        //    clsItemBL ItemSelection = (clsItemBL) dgItemSearch.SelectedItem;
        //tbItemSearch.Text = ItemSelection.AuthorName;
        //Get Objects

       
        public ObservableCollection<UserReadDto> Users { get; set; }
        public IIntegrationService Api { get; set; }

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

        public ManageCustomerModel()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        public ManageCustomerModel(ServiceProvider serviceProvider)
        {
            Api = serviceProvider.GetService<IIntegrationService>();
            
            Users = new ObservableCollection<UserReadDto>();
            Users.Clear();

            //HERE BE API TESTS: enjoy

            //putInTestValues(); //adding some tags into db for testing
            // testGetSingle();
            testGetTable();
            //testInsert();
           //testUpdate();
           //testDelete();
        }

        /// <summary>
        /// The Command  to change the Database Entries through the DataGrid.
        /// </summary>
        public ICommand ChangeEntry => new BaseCommand(() =>
        {

         UserReadDto customer = (UserReadDto)SelectedRecord;
         var usersLocal = Api.GetTable<UserReadDto>("users");
         UserReadDto userToBeUpdated = usersLocal.Find(x => x.UserID == SelectedRecord.UserID);
         if (userToBeUpdated == null) return;

           //and now update the title
           UserUpdateDto updatingTag = new UserUpdateDto()
           {
               Address = SelectedRecord.Address, Email = SelectedRecord.Email, Name = SelectedRecord.Name, Password = SelectedRecord.Password, PhoneNumber = SelectedRecord.PhoneNumber, UserID = SelectedRecord.UserID,UserStatusID = SelectedRecord.UserStatusID

           }; //supplying primary key, so db knows which entry to update with rest of attributes
           var tagUpdateResponse = Api.Update<UserUpdateDto>($"users/{SelectedRecord.UserID}", updatingTag);
           MessageBox.Show(tagUpdateResponse.ToString());
           //fetching newly created tag to update it with another title, since i just made it, it has to have the highest id

           //       //fetching newly created tag to update it with another title, since i just made it, it has to have the highest id
           //       var tagList = Api.GetTable<TagReadDto>("tags");
           //       TagReadDto tagToBeUpdated = tagList.Find(x => x.TagID == tagList.Max(t => t.TagID));
           //       if (tagToBeUpdated == null) return;

           //       //and now update the title
           //       TagUpdateDto updatingTag = new TagUpdateDto() { TagID = tagToBeUpdated.TagID, Title = "AHUGIZDASD" }; //supplying primary key, so db knows which entry to update with rest of attributes
           //       var tagUpdateResponse = Api.Update<TagUpdateDto>("tags", updatingTag);

        });



        #region TestMethods
        /// <summary>
        /// Getting a single entry through the DTO
        /// </summary>
        void testGetSingle()
        {
            var tagDto = Api.GetSingleEntryById<TagReadDto>("tags", 1);
            MessageBox.Show("TagID: " + tagDto.TagID + " TagTitle: " + tagDto.Title, "GetSingle test");
        }

        /// <summary>
        /// Getting a table entry through the DTO
        /// </summary>
        void testGetTable()
        {
            var entries = Api.GetTable<UserReadDto>("users");
            foreach (UserReadDto tag in entries)
            {
                Users.Add(tag);
            }

        }
        /// <summary>
        /// Getting an insert entry through the DTO
        /// </summary>
        void testInsert()
        {
            var tagToBeInserted = new TagCreateDto { Title = "this tag has just been inserted" }; //NOT supplying primary key, db will auto increment itself
            var insertResponse = Api.Insert<TagCreateDto>("tags", tagToBeInserted);
            MessageBox.Show(insertResponse.ToString(), "too lazy to make this readable... but it worked!");
        }

        /// <summary>
        /// Updating through the DTO
        /// </summary>
        void testUpdate()
        {
            //fetching newly created tag to update it with another title, since i just made it, it has to have the highest id
            var tagList = Api.GetTable<TagReadDto>("tags");
            TagReadDto tagToBeUpdated = tagList.Find(x => x.TagID == tagList.Max(t => t.TagID));
            if (tagToBeUpdated == null) return;

            //and now update the title
            TagUpdateDto updatingTag = new TagUpdateDto() { TagID = tagToBeUpdated.TagID, Title = "this just updated the title" }; //supplying primary key, so db knows which entry to update with rest of attributes
            var tagUpdateResponse = Api.Update<TagUpdateDto>("tags", updatingTag);
            MessageBox.Show("if this responds a 204: no content, that means it works! \b" + tagUpdateResponse.ToString(), "again too lazy to make this readable... but it worked!");
        }

        /// <summary>
        /// Deleting via DTO
        /// </summary>
        void testDelete()
        {
            //fetching newly created tag's id to delete it
            var tagCollection = Api.GetTable<TagReadDto>("tags");
            int tagId = 0;
            foreach (TagReadDto tag in tagCollection)
            {
                if (tag.TagID > tagId) tagId = tag.TagID;
            }
            if (tagId < 1) return;

            //and now delete it
            var tagDeletionResponseMessage = Api.Delete("tags", tagId);
            MessageBox.Show("if this responds a 204: no content, that means it works! \b" + tagDeletionResponseMessage.ToString(), "Make this readable? hell naw");
        }

        #endregion
    }
}