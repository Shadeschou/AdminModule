using System;
using System.Collections.Generic;
using System.Windows.Input;
using AdminModule.utility;
using GalaSoft.MvvmLight.Messaging;

namespace AdminModule.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand CustomCommand { get; set; }

        public MainWindowViewModel()
        {
            SelectedViewModel = new ManageCustomerModel();
            CustomCommand = new CustomCommand(this);
        }
    }
}