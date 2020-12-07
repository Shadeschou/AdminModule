using System;
using System.Windows;
using System.Windows.Input;
using AdminModule.ViewModels;

namespace AdminModule.utility
{
    public class CustomCommand : ICommand
    {
        private MainWindowViewModel viewmodel;

        public CustomCommand(MainWindowViewModel viewmodel)
        {
            this.viewmodel = viewmodel; //hi I guess Gr8
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString().ToLower())
            {
                case "add customer" :
                    viewmodel.SelectedViewModel = new AddCustomerModel();
                    break;
                case "delete customer":
                    viewmodel.SelectedViewModel = new DeleteCustomerModel();
                    break;
                case "manage customer":
                    viewmodel.SelectedViewModel = new ManageCustomerModel();
                    break;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}