using System;

namespace WpfStudy.Commands
{
    public class RelayCommand : RelayCommandBase
    {
        private readonly Func<bool> canExecute;

        private readonly Action execute;

        public RelayCommand(Action execute) : this(execute,()=>true)
        {
            this.execute = execute;
            this.canExecute = () => true;
        }

        public RelayCommand(Action execute,Func<bool> canExecute):base(o => execute(),o=>canExecute())
        {
            if (execute == null || canExecute == null)
                throw new ArgumentNullException("execute", "DelegateCommandDelegatesCannotBeNull");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute()
        {
            this.execute();
        }

        public void CanExecute()
        {
            this.canExecute();
        }
    }


    public class RelayCommand<T> : RelayCommandBase
    {
        public RelayCommand(Action<T> execute):this(execute,_=>true)
        {
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
            : base(o => execute((T)o), o => canExecute((T)o))
        {
            if (execute == null || canExecute == null)
                throw new ArgumentNullException("execute", "DelegateCommandDelegatesCannotBeNull");
        }

        public void Execute(T parameter)
        {
            this.Execute(null);
        }

        public bool CanExecute(T parameter)
        {
            return this.CanExecute(null);
        }
    }
}
