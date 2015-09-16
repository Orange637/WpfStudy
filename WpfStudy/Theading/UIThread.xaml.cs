using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfStudy.Theading
{
    /// <summary>
    /// Interaction logic for UIThread.xaml.
    /// </summary>
    public partial class UIThread : INotifyPropertyChanged
    {
        private int bindingText;

        public UIThread()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int BindingText
        {
            get
            {
                return this.bindingText;
            }

            set
            {
                this.bindingText = value;
                this.OnPropertyChanged("BindingText");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1000000; i++)
            {
                this.BindingText = i;
            }

            for (int i = 0; i < 1000000; i++)
            {
                this.TextBlock2.Text = i.ToString();
            }
        }

        private void CalculateWithSubThread(object sender, RoutedEventArgs e)
        {
            var subThread = new Thread(new ThreadStart(Calculate));
            subThread.SetApartmentState(ApartmentState.STA);
            // subThread.IsBackground = true;
            subThread.Start();
        }

        private void Calculate()
        {
            for (int i = 0; i < 10000000; i++)
            {
                this.BindingText = i;
            }
        }

        private void CalculateWithBackgroundThread(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100000; i++)
            {
                ThreadPool.QueueUserWorkItem(
                    obj =>
                        {
                            var number = int.Parse(obj.ToString());
                            number += 1;
                            Application.Current.Dispatcher.BeginInvoke(
                                new Action(
                                    () =>
                                        { this.BindingText = number; }));
                        },
                    i);

            }
        }
    }
}
