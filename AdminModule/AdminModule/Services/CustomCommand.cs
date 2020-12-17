using System;
using System.Windows.Input;
using AdminModule.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminModule.utility
{
    public class CustomCommand : ICommand
    {
        private readonly MainWindowViewModel viewmodel;
        public ServiceProvider serviceProvider;

        public CustomCommand(MainWindowViewModel viewmodel, ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.viewmodel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString().ToLower())
            {
                case "add customer":
                    viewmodel.SelectedViewModel = new AddCustomerModel(serviceProvider);
                    break;
                case "delete customer":
                    viewmodel.SelectedViewModel = new DeleteCustomerModel(serviceProvider);
                    break;
                case "manage customer":
                    viewmodel.SelectedViewModel = new ManageCustomerModel(serviceProvider);
                    break;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}