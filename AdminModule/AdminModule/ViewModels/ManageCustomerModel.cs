using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using AdminModule.Services;
using DataLayer.Dtos;


namespace AdminModule.ViewModels
{
    internal class ManageCustomerModel : BaseViewModel
    {
        //Get Objects
        public ObservableCollection<UserReadDto> Users { get; set; }
        


        public ManageCustomerModel()
        {
            GetResource();
            //PatchResource().GetAwaiter();

        }
        public async Task GetResource()
        {
            var response = await APIService._httpClient.GetAsync("api/users");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var users = new List<UserReadDto>();
            MessageBox.Show(users.ToString());
        }
        //public async Task GetResource()
        //{
        //    //API Default to JSON so we use it. 
        //    var response = await APIService._httpClient.GetAsync("api/users");
        //    response.EnsureSuccessStatusCode();
        //    var content = await response.Content.ReadAsStringAsync();
        //    Users = new ObservableCollection<UserReadDto>();
        //    Users = JsonConvert.DeserializeObject<ObservableCollection<UserReadDto>>(content);

        //}




        //public async Task PatchResource()
        //{
        //    var patchDoc = new JsonPatchDocument<UserReadDto>();

        //    patchDoc.Replace(m => m.Email, "Updated Title");
        //    //patchDoc.Remove(m => m.Description);

        //    var serializedChangeSet = JsonConvert.SerializeObject(patchDoc);

        //    var request = new HttpRequestMessage(HttpMethod.Put,
        //        "http://localhost:46897");
        //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    request.Content = new StringContent(serializedChangeSet);
        //    request.Content.Headers.ContentType =
        //        new MediaTypeHeaderValue("application/json-patch+json");

        //    var response = await APIService._httpClient.SendAsync(request);
        //    response.EnsureSuccessStatusCode();

        //    var content = await response.Content.ReadAsStringAsync();
        //    var updatedMovie = JsonConvert.DeserializeObject<UserUpdateDto>(content);
        //    MessageBox.Show("DonePatch");
        //}





    }
}