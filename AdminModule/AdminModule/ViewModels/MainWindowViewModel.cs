using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AdminModule.Services;
using AdminModule.utility;
using Microsoft.Extensions.DependencyInjection;


namespace AdminModule.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public MainWindowViewModel()
        {
            CustomCommand = new CustomCommand(this);
            SelectedViewModel = new ManageCustomerModel();
        }

        public BaseViewModel SelectedViewModel {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand CustomCommand { get; set; }

        //Start of Client 
        public async Task Startup()
        {
            // create a new ServiceCollection 
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            // create a new ServiceProvider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Run our IntegrationService containing all samples and
            // await this call to ensure the application doesn't 
            // prematurely exit.
                await serviceProvider.GetService<IIntegrationService>().Run();
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IIntegrationService, APIService>();
        }
    }
}