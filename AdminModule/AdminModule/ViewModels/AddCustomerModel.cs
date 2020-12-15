using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AdminModule.Services;
using AdminModule.Views;
using DataLayer.Dtos;
using Newtonsoft.Json;


namespace AdminModule.ViewModels
{
    public class AddCustomerModel : BaseViewModel
    {
        public int UserIDInput { get; set; } // PK
        public string PasswordInput { get; set; } //Just for Convenience as this is part of the DB
        public string AddressInput{ get; set; }
        public int PhoneNumberInput { get; set; }
        public string EmailInput { get; set; }
        public int UserStatusIDInput { get; set; } //FK
        public string NameInput { get; set; }

        public AddCustomerModel()
        {
           
            PostData();
            if (PostData().GetAwaiter().IsCompleted)
            {
                MessageBox.Show("Hi"); 
            }

        }
        public async Task PostData()
        {
            
            var customerToCreate = new UserCreateDto()
            {
                Address = "AddressInput",
                Name = "NameInput",
                PhoneNumber = 1234124,
                Email = "EmailInput"
            };

            var serializedCustomer = JsonConvert.SerializeObject(customerToCreate);

                var request = new HttpRequestMessage(HttpMethod.Post, "api/users");
                //Returned object in a newly created response Body. 
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedCustomer);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //we call async to pass through the request
                var response = await APIService._httpClient.SendAsync(request);
                //we ensure success response.
                response.EnsureSuccessStatusCode();
                //We read Content
                var content = await response.Content.ReadAsStringAsync();
            

                var createdUser = JsonConvert.DeserializeObject<UserCreateDto>(content);

          


    }


    }
}