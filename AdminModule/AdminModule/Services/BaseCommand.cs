using System;
using System.Windows.Input;

namespace AdminModule.Services
{
    /// <summary>
    /// The Base command for implementing the ICommand functionality for each following command. 
    /// </summary>
    public class BaseCommand : ICommand
    {
        #region Private Fields
        private readonly Func<bool> canExecuteEvaluator;

        private readonly Action methodToExecute;
        #endregion

        #region Overloaded Constructors
        public BaseCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public BaseCommand(Action methodToExecute)
            : this(methodToExecute, null)
        {
        }
        #endregion

        #region EventHandler
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            if (canExecuteEvaluator == null)
            {
                return true;
            }

            var result = canExecuteEvaluator.Invoke();
            return result;
        }

        public void Execute(object parameter)
        {
            methodToExecute.Invoke();
        } 
        #endregion
    }
}