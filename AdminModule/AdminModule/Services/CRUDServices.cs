using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdminModule.Services
{
    class CRUDServices
    {
        private static HttpClient _httpClient = new HttpClient();

        public CRUDServices()
        {
            // set up HttpClient instance
            _httpClient.BaseAddress = new Uri("http://localhost:57863");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
          
        }

        public async Task Run()
        {
            // await GetResource();
            // await GetResourceThroughHttpRequestMessage();
            // await CreateResource();
            // await UpdateResource();
            // await DeleteResource();
        }


    }
}
