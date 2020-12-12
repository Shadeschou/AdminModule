using System;
using System.Net.Http;
using System.Windows;
using AdminModule.Models;

namespace AdminModule.ViewModels
{
    internal class ManageCustomerModel : BaseViewModel
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public ManageCustomerModel()
        {

        }


    }
}