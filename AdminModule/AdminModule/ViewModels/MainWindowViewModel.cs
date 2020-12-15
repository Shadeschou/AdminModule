using AdminModule.Services;
using AdminModule.utility;
using Microsoft.Extensions.DependencyInjection;

namespace AdminModule.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
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

        public MainWindowViewModel()
        {
            Startup();            
        }
        
        public void Startup()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
            //testmethod
            CustomCommand = new CustomCommand(this, serviceProvider);
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IIntegrationService, APIService>();
        }
    }
}