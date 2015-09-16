namespace WpfStudy.Commands
{
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for RelayCommandTest.xaml
    /// </summary>
    public partial class RelayCommandTest : INotifyPropertyChanged
    {
        public RelayCommandTest()
        {
            InitializeComponent();

            this.CommandOne = new RelayCommand(this.ExecuteCommandOne);
            this.OnPropertyChanged("CommandOne");

            this.CommandTwo = new RelayCommand<string>(this.ExecuteCommandTwo);
            this.OnPropertyChanged("CommandTwo");

            this.CommandThree = new RelayCommand<int>(this.ExecuteCommandThree);
            this.OnPropertyChanged("CommandThree");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand CommandOne { get; private set; }

        public RelayCommand<string> CommandTwo { get; private set; }

        public RelayCommand<int> CommandThree { get; private set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ExecuteCommandOne()
        {
            MessageBox.Show("Click One -> CommandOne!");
        }

        private void ExecuteCommandTwo(string parameter)
        {
            MessageBox.Show(parameter);
        }

        private void ExecuteCommandThree(int obj)
        {
            MessageBox.Show(obj.ToString());
        }
    }
}
