using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfStudy.Bindings
{
    /// <summary>
    /// Interaction logic for Validation2.xaml.
    /// </summary>
    public partial class Validation2 : INotifyPropertyChanged
    {
        public Validation2()
        {
            InitializeComponent();
        }

        private string int_EXP;

        public string Int_EXP
        {
            get { return this.int_EXP; }
            set
            {
                this.int_EXP = value; 
                
                
                this.OnPropertyChanged("Int_EXP");

                /*int age;
                if (!int.TryParse(int_EXP, out age))
                {
                    throw new ArgumentException("Must be a number!");
                }

                if (age < 18)
                {
                    throw new ArgumentException("Must biger than 18!");
                }*/
            }
        }
        private string int_NOM;

        public string Int_NOM
        {
            get { return this.int_NOM; }
            set
            {
                this.int_NOM = value; this.OnPropertyChanged("Int_NOM");
            }
        }
        private string int_DEI;

        public string Int_DEI
        {
            get { return this.int_DEI; }
            set
            {
                this.int_DEI = value; this.OnPropertyChanged("Int_DEI");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Int_DEI = string.Empty;
            this.Int_EXP = string.Empty;
            this.Int_NOM = string.Empty;
        }

        private void tieEX_Loaded(object sender, RoutedEventArgs e)
        {

            BindingOperations.GetBindingExpression(tieEX, TextBox.TextProperty).UpdateSource();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
