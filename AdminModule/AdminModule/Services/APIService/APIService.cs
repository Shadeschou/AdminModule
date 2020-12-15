using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using DataLayer.Dtos;

namespace AdminModule.Services
{
    public class APIService : IIntegrationService
    {
        public static HttpClient _httpClient { get; set;  }

        public static void InitClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:46897"), Timeout = new TimeSpan(0, 0, 30)
            };
            // set up HttpClient instance
            _httpClient.DefaultRequestHeaders.Clear();

        }

        public async Task Run()
        {
           await GetResource();
        //    //await GetResourceThroughHttpRequestMessage();
        }

       public async Task GetResource()
       {
           //API Default to JSON so we use it. 
           var response = await _httpClient.GetAsync("api/ideas");
           response.EnsureSuccessStatusCode();
           var content = await response.Content.ReadAsStringAsync();
           var ideas = new List<IdeaReadDto>();

           ideas = JsonConvert.DeserializeObject<List<IdeaReadDto>>(content);

           //Be as strict as possible with the Headers - We should have them for RESTfull api. 
           if (response.Content.Headers.ContentType.MediaType == "")
           {
               //NOT SURE ABOUT IDEAREAD
               ideas = JsonConvert.DeserializeObject<List<IdeaReadDto>>(content);
           }
           else if (response.Content.Headers.ContentType.MediaType == "application/xml")
           {
               //NOT SURE ABOUT IDEAREAD
               var serializer = new XmlSerializer(typeof(List<IdeaReadDto>));
               ideas = (List<IdeaReadDto>) serializer.Deserialize(new StringReader(content));
           }
       }

        /*
        /// <summary>
        /// We want to be able to Get Data which does not change through our runtime and because we want to 
        /// be able to use 
        /// </summary>
        /// <returns></returns>
        //public async Task GetResourceThroughHttpRequestMessage()
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Get, "api/movies");
        //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var response = await _httpClient.SendAsync(request);

        //    response.EnsureSuccessStatusCode();

        //    var content = await response.Content.ReadAsStringAsync();
        //    var movies = JsonConvert.DeserializeObject<List<IdeaReadDto>>(content);

        //}

        /// <summary>
        /// Send Data to be able to show it on the WPF page. 
        /// </summary>
        /// <returns></returns>
      

        //private async Task DeleteResource()
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Delete,
        //        "api/movies/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b");
        //    //we need that in case the API would return content in the case of a failure. 
        //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    var response = await _httpClient.SendAsync(request);
        //    response.EnsureSuccessStatusCode();

        //    var content = await response.Content.ReadAsStringAsync();
        //}
        */
    }
}

