﻿using System.Collections.Generic;
using System.Runtime.InteropServices;
using AdminModule.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdminModule.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        public MainWindowViewModel()
        {
            Startup();
        }

        public ServiceProvider serviceProvider { get; set; }
        public CustomCommand CustomCommand { get; set; }

        public BaseViewModel SelectedViewModel
        {

            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        } 

        public void Startup()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
            CustomCommand = new CustomCommand(this, serviceProvider);
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IIntegrationService, APIService>();
        }
    }
}