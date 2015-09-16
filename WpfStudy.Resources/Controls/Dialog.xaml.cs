namespace TaskVision.Resources.Controls
{
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for Dialog.xaml.
    /// </summary>
    public partial class Dialog : INotifyPropertyChanged
    {
        private readonly MessageDialogImage image;

        private string message;

        public Dialog(
            string messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageDialogImage icon,
            MessageBoxResult defaultResult)
        {
            InitializeComponent();

            this.Message = messageBoxText;
            this.Title = caption;
            this.image = icon;
            this.OnPropertyChanged("Image");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Image
        {
            get
            {
                switch (this.image)
                {
                    case MessageDialogImage.None:
                        return null;
                        case MessageDialogImage.Information:
                        return "/Resources;component/Assets/Images/Info.png";
                        case MessageDialogImage.Warning:
                        return "/Resources;component/Assets/Images/Warning.png";
                        case MessageDialogImage.Error:
                        return "/Resources;component/Assets/Images/Error.png";
                    default:
                        return null;
                }
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
