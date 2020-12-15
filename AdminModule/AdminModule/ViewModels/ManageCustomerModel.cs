using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using AdminModule.Services;
using DataLayer.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace AdminModule.ViewModels
{
    internal class ManageCustomerModel : BaseViewModel
    {
        //Get Objects
        public ObservableCollection<UserReadDto> Users { get; set; }
        public IIntegrationService Api { get; set; }

        public List<UserReadDto> users;

        public ManageCustomerModel(ServiceProvider serviceProvider)
        {
            Api = serviceProvider.GetService<IIntegrationService>();

            //HERE BE API TESTS: enjoy

            //requesting user with id no 1, providing the Dto type in which the returned json is automatically converted
            testSingle();

            //requesting whole idea table, providing Dto type which will be referenced by ObservableCollection
            testTable();

            //inserting single entry into tags table, providing dto type because it is converted to json for transmit
            testInsert();

            //changing the newly added tag
            testUpdate();

            //delete single entry from tags table again
            testDelete();
        }

        void testSingle()
        {
            var userDto = Api.GetSingleEntryById<UserReadDto>("users", 1);
            MessageBox.Show("Name: " + userDto.Name + " ID: " + userDto.UserID, "UserDto Test");
        }

        void testTable()
        {
            var ideaList = Api.GetTable<IdeaReadDto>("ideas");
            MessageBox.Show(ideaList.ToString(), "Too lazy to make this output beautiful...");
        }

        void testInsert()
        {
            var tagToBeInserted = new TagCreateDto { Title = "this tag has just been inserted" }; //NOT supplying primary key, db will auto increment itself
            var insertResponse = Api.Insert<TagCreateDto>("tags", tagToBeInserted);
            MessageBox.Show(insertResponse.ToString(), "this should be the whole status message response");
        }

        void testUpdate()
        {
            //fetching newly created tag to update it with another title, since i just made it, it has to have the highest id
            var tagList = Api.GetTable<TagReadDto>("tags");
            TagReadDto tagToBeUpdated = tagList.Find(x => x.TagID == tagList.Max(t => t.TagID));
            if (tagToBeUpdated == null) return;

            //and now update the title
            TagUpdateDto updatingTag = new TagUpdateDto() { TagID = tagToBeUpdated.TagID, Title = "this just updated the title" }; //supplying primary key, so db knows which entry to update with rest of attributes
            var tagUpdateResponse = Api.Update<TagUpdateDto>("tags", updatingTag);
            MessageBox.Show(tagUpdateResponse.ToString() ,"Updated Tag's response:");
        }

        void testDelete()
        {
            //fetching newly created tag's id to delete it
            var tagCollection = Api.GetTable<TagReadDto>("tags");
            int tagId = 0;
            foreach(TagReadDto tag in tagCollection)
            {
                if (tag.TagID > tagId) tagId = tag.TagID;
            }
            if (tagId < 1) return;

            //and now delete it
            var tagDeletionResponseMessage = Api.Delete("tags", tagId);
            MessageBox.Show(tagDeletionResponseMessage.ToString(), "Make this readable? hell naw");
        }
    }
}