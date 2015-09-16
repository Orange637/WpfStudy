using System;
using System.Windows.Input;

namespace WpfStudy.Commands
{
    public class RelayCommandBase : ICommand
    {
        private readonly Action<object> executeMethod;
        private readonly Func<object, bool> canExecuteMethod;

        protected RelayCommandBase(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            if (executeMethod == null || canExecuteMethod == null)
                throw new ArgumentNullException("executeMethod", "Delegate Command Delegates Cannot Be Null");

            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public void Execute(object parameter)
        {
            this.executeMethod(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteMethod == null || canExecuteMethod(parameter);
        }
        
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
