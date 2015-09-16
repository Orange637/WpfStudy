using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfStudy.BasicControls
{
    /// <summary>
    /// Interaction logic for DragDropListBox.xaml
    /// </summary>
    public partial class DragDropListBox : INotifyPropertyChanged
    {
        public DragDropListBox()
        {
            InitializeComponent();

            ItemsControlItems = new ObservableCollection<string>
                {
                    "1adfafadfasdfaf",
                    "2yyyadferqwtrta",
                    "3yyyadferqwtrta",
                    "4yyyadferqwtrta",
                    "5yyyadferqwtrta",
                    "6yyyadferqwtrta",
                    "7yyyadferqwtrta",
                    "8yyyadferqwtrta",
                    "9yyyadferqwtrta",
                    "Ayyyadferqwtrta",
                    "Byyyadferqwtrta",
                    "Cyyyadferqwtrta",
                    "Dyyyadferqwtrta",
                    "Eyyyadferqwtrta",
                    "Fyyyadferqwtrta",
                    "Gyyyadferqwtrta",
                    "Hyyyadferqwtrta"
                };
            ListBoxItems = new ObservableCollection<string>();
            ListViewItems = new ObservableCollection<string>();

            OnPropertyChanged("ItemsControlItems");
            OnPropertyChanged("ListBoxItems");
            OnPropertyChanged("ListViewItems");
        }

        public ObservableCollection<string> ItemsControlItems { get; set; }
        public ObservableCollection<string> ListBoxItems { get; set; }
        public ObservableCollection<string> ListViewItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
