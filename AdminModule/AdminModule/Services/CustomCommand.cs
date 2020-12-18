using System;
using System.Windows.Input;
using AdminModule.ViewModels;
using DataLayer.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace AdminModule.Services
{
    /// <summary>
    /// The Command to be implemented the different
    /// 
    /// </summary>
    public class CustomCommand : ICommand
    {
        #region Private Fields
        private readonly MainWindowViewModel viewmodel;
        #endregion

        #region Public fields
        public ServiceProvider serviceProvider;
        public event EventHandler CanExecuteChanged;
        internal AddCustomerModel addModel;
        internal DeleteCustomerModel deleteModel;
        internal ManageCustomerModel manageModel;
        #endregion

        #region Constructor
        public CustomCommand(MainWindowViewModel viewmodel, ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.viewmodel = viewmodel;
            //Making sure the models will be able to fire their commands and recognise the API 
            addModel = new AddCustomerModel(serviceProvider);
            deleteModel = new DeleteCustomerModel(serviceProvider);
            manageModel = new ManageCustomerModel(serviceProvider);
            //Empowering more intuitive DataGrids 
            deleteModel.Api.GetTable<UserReadDto>("users");
            manageModel.Api.GetTable<UserReadDto>("users");
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// The switch execution given the button press from the MainWindow
        /// This will take the CommandParameter and change the ContentControl inside the MainWindow
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            switch (parameter.ToString().ToLower())
            {
                case "add customer":
                    viewmodel.SelectedViewModel = addModel;
                   break;
                case "delete customer":
                    viewmodel.SelectedViewModel = deleteModel;
                    break;
                case "manage customer":
                    viewmodel.SelectedViewModel = manageModel;
                    break;
            }
        } 
        #endregion

        
    }
}