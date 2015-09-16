namespace WpfStudy.Commands
{
    using System;
    using System.IO;
    using System.Windows.Input;

    using WpfStudy.Model;

    public class ResetCommand : ICommand
    {
        private readonly ImageData data;

        public ResetCommand(ImageData data)
        {
            this.data = data;
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

        public void Execute(object parameter)
        {
            this.data.Zoom = 1.0;
        }

        public bool CanExecute(object parameter)
        {
            return this.data != null && File.Exists(this.data.SourcePath);
        }
    }
}
