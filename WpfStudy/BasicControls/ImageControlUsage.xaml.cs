using System.ComponentModel;
using System.IO;
using System.Windows;

namespace WpfStudy.BasicControls
{
    /// <summary>
    /// Interaction logic for ImageControlUsage.xaml.
    /// </summary>
    public partial class ImageControlUsage : INotifyPropertyChanged
    {
        private string _imageSourceUri;

        private byte[] _imageSourceBytes;

        private string _imageSourceNullUri;

        public string ImageSourceNullUri
        {
            get { return _imageSourceNullUri; }
            set { _imageSourceNullUri = value;this.OnPropertyChanged("ImageSourceNullUri"); }
        }


        public ImageControlUsage()
        {
            var prop = DesignerProperties.IsInDesignModeProperty;
            var design = (bool)DependencyPropertyDescriptor.FromProperty(
            prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            if (design)
            {
                MessageBox.Show("In design;");
                this.ImageSourceUri = @"/WpfStudy.Resources;component/Images/Color.jpg";
            }


            if (
                (bool)
                DependencyPropertyDescriptor.FromProperty(
                    DesignerProperties.IsInDesignModeProperty, typeof(FrameworkElement)).Metadata.DefaultValue)
            {
                this.ImageSourceUri = @"/WpfStudy.Resources;component/Images/Color.jpg";
            }

            InitializeComponent();

            this.ImageSourceUri = @"/WpfStudy.Resources;component/Images/Color.jpg";

            this.ImageSourceBytes = File.ReadAllBytes(@"D:\4.Projects\VS2012\WPF\WpfStudy\WpfStudy.Resources\Images/Color.jpg");

            this.ImageSourceNullUri = null;
        }

        public string ImageSourceUri
        {
            get { return _imageSourceUri; }
            set { _imageSourceUri = value;this.OnPropertyChanged("ImageSourceUri"); }
        }

        public byte[] ImageSourceBytes
        {
            get
            {
                return _imageSourceBytes;
            }
            set
            {
                _imageSourceBytes = value;
                this.OnPropertyChanged("ImageSourceBytes");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
