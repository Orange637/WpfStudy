namespace WpfStudy.Theading
{
    using System;
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for BusyIndicator2.xaml.
    /// </summary>
    public partial class BusyIndicator2 : INotifyPropertyChanged
    {
        public BusyIndicator2()
        {
            InitializeComponent();
        }

        private bool isBusy1;

        private bool isBusy2;

        private bool isBusy3;

        private bool isBusy4;

        public bool IsBusy4
        {
            get
            {
                return isBusy4;
            }

            set
            {
                isBusy4 = value;
                this.OnPropertyChanged("IsBusy4");
            }
        }


        public bool IsBusy3
        {
            get { return isBusy3; }
            set { isBusy3 = value; this.OnPropertyChanged("IsBusy3");}
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy1
        {
            get
            {
                return this.isBusy1;
            }

            set
            {
                this.isBusy1 = value;
                this.OnPropertyChanged("IsBusy1");
            }
        }

        public bool IsBusy2
        {
            get
            {
                return this.isBusy2;
            }

            set
            {
                this.isBusy2 = value;
                this.OnPropertyChanged("IsBusy2");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ShowBusyIndicator1(object sender, RoutedEventArgs e)
        {
            this.IsBusy1 = !this.isBusy1;
        }

        private void ShowBusyIndicator2(object sender, RoutedEventArgs e)
        {
            this.IsBusy2 = !this.isBusy2;
        }

        private void ShowBusyIndicator3(object sender, RoutedEventArgs e)
        {
            this.IsBusy3 = !this.isBusy3;
        }

        private void ShowBusyIndicator4(object sender, RoutedEventArgs e)
        {

            this.IsBusy4 = !this.isBusy4;
        }
    }
}
