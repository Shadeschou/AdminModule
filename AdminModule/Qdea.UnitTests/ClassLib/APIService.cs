using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using Newtonsoft.Json;

namespace AdminModule.Services
{
    #region interface IntegrationService
    public interface IIntegrationService
    {
        Dto GetSingleEntryById<Dto>(string table, int id);
        List<Dto> GetTable<Dto>(string table);
        HttpResponseMessage Insert<Dto>(string table, Dto entry);
        HttpResponseMessage Update<Dto>(string table, Dto dtoToUpdate);
        HttpResponseMessage Delete(string table, int id);
    } 
    #endregion

    public class APIService : IIntegrationService
    {
        #region Constructor
        public APIService()
        {
            InitClient();
        }
        #endregion

        #region Fields
        public static HttpClient _httpClient { get; set; }
        #endregion

        #region Methods
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

        public HttpResponseMessage Insert<Dto>(string table, Dto entry)
        {
            using (var response = _httpClient.PostAsJsonAsync($"api/{table}", entry))
            {
                return response.Result;
            }
        }

        public HttpResponseMessage Update<Dto>(string table, Dto dtoToUpdate)
        {
            using (var response = _httpClient.PutAsJsonAsync($"api/{table}", dtoToUpdate))
            {
                return response.Result;
            }
        }

        public HttpResponseMessage Delete(string table, int id)
        {
            using (var response = _httpClient.DeleteAsync($"api/{table}/{id}"))
            {
                return response.Result;
            }
        }

        public void InitClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:46897/") };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        } 
        #endregion
    }
}