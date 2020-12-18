using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Adminmodule.UnitTests
{
    [TestClass]
    public class ApiServiceTests
    {
        [TestMethod]
        public void TestGetSingleEntryById()
        {
            //arrange
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IIntegrationService, APIService>();
            serviceProvider = serviceCollection.BuildServiceProvider();
            CustomCommand = new CustomCommand(this, serviceProvider);

            //act


            //assert

            var tagDto = Api.GetSingleEntryById<TagReadDto>("tags", 1);
            MessageBox.Show("TagID: " + tagDto.TagID + " TagTitle: " + tagDto.Title, "GetSingle test");
        }
        [TestMethod]
        public void TestGetTable()
        {

        }
        [TestMethod]
        public void TestInsert()
        {

        }
        [TestMethod]
        public void TestUpdate()
        {

        }
        [TestMethod]
        public void TestDelete()
        {

        }
    }
}
