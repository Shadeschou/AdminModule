using System.Windows.Input;
using AdminModule.utility;

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

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand CustomCommand { get; set; }
    }
}