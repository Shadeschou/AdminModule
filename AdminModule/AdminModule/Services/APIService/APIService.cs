using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace AdminModule.Services
{
    public interface IIntegrationService
    {
        Dto GetSingleEntryById<Dto>(string table, int id);
        List<Dto> GetTable<Dto>(string table);
        HttpResponseMessage Insert<Dto>(string table, Dto entry);
        HttpResponseMessage Update<Dto>(string table, Dto dtoToUpdate);
        HttpResponseMessage Delete(string table, int id);
    }

    public class APIService : IIntegrationService
    {
        public static HttpClient _httpClient { get; set; }

        public APIService()
        {
            InitClient();
        }

        public void InitClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:46897/") };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }        

        public Dto GetSingleEntryById<Dto>(string table, int id)
        {
            using (var response = _httpClient.GetAsync($"api/{table}/{id}").Result.Content.ReadAsStringAsync())
            {
                return JsonConvert.DeserializeObject<Dto>(response.Result);
            }
        }

        public List<Dto> GetTable<Dto>(string table)
        {
            using (var response = _httpClient.GetAsync($"api/{table}").Result.Content.ReadAsStringAsync())
            {
                return JsonConvert.DeserializeObject<List<Dto>>(response.Result);
            }
        }

        public HttpResponseMessage Insert<Dto>(string table,Dto entry)
        {
            var data = new StringContent(JsonConvert.SerializeObject(entry),Encoding.UTF8,"application/json");
            using(var response = _httpClient.PostAsJsonAsync<Dto>($"api/{table}", entry))
            {
                MessageBox.Show(response.Result.ToString());
                return response.Result;
            }
        }

        public HttpResponseMessage Update<Dto>(string table, Dto dtoToUpdate)
        {
            using (var response = _httpClient.PutAsJsonAsync<Dto>($"api/{table}", dtoToUpdate))
            {
                return response.Result;
            }
        }

        public HttpResponseMessage Delete(string table, int id)
        {
            using(var response = _httpClient.DeleteAsync($"api/{table}/{id}"))
            {
                return response.Result;
            }
        }
    }
}

