using AdminModule.Services;
using DataLayer.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AdminModule.UnitTests
{
    [TestClass]
    class ServiceTests
    {
        [TestMethod]
        public void TestGetSingleEntryById()
        {
            //arrange
            var Api = new APIService();

            //act
            var tagDto = Api.GetSingleEntryById<TagReadDto>("tags", 1);

            //assert
            Assert.IsNotNull(tagDto);
        }
        [TestMethod]
        public void TestGetTable()
        {
            //arrange
            var Api = new APIService();

            //act
            var entries = Api.GetTable<UserReadDto>("users");

            //assert
            Assert.IsNotNull(entries);


        }
        [TestMethod]
        public void TestInsert()
        {
            //arrange
            var Api = new APIService();
            var tagToBeInserted = new TagCreateDto { Title = "this tag has just been inserted" };

            //act
            var insertResponse = Api.Insert("tags", tagToBeInserted);

            //assert
            Assert.IsNotNull(insertResponse);
        }
        [TestMethod]
        public void TestUpdate()
        {
            //arrange
            var Api = new APIService();
            var tagToBeInserted = new TagCreateDto { Title = "this tag has just been inserted" };

            //act
            var tagList = Api.GetTable<TagReadDto>("tags");
            var tagToBeUpdated = tagList.Find(x => x.TagID == tagList.Max(t => t.TagID));
            var updatingTag = new TagUpdateDto
            {
                TagID = tagToBeUpdated.TagID,
                Title = "this just updated the title"
            };
            var tagUpdateResponse = Api.Update("tags", updatingTag);

            //assert
            Assert.IsNotNull(tagUpdateResponse);

        }
        [TestMethod]
        public void TestDelete()
        {
            //arrange
            var Api = new APIService();

            //act
            var tagCollection = Api.GetTable<TagReadDto>("tags");
            var tagId = 0;
            foreach (var tag in tagCollection)
            {
                if (tag.TagID > tagId) tagId = tag.TagID;
            }
            var tagDeletionResponseMessage = Api.Delete("tags", tagId);
            //assert
            Assert.IsNotNull(tagDeletionResponseMessage);
        }
    }
}
