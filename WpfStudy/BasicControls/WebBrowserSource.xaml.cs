namespace WpfStudy.BasicControls
{
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for WebBrowserSource.xaml
    /// </summary>
    public partial class WebBrowserSource : INotifyPropertyChanged
    {
        private string url;

        public WebBrowserSource()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.OnPropertyChanged("Url");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Url = "http://www.baidu.com";
        }
    }
}
