using System;
using System.Collections.Generic;
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

namespace WpfStudy.Behaviors
{
    /// <summary>
    /// Interaction logic for ShowDialog.xaml
    /// </summary>
    public partial class ShowDialog : Window
    {
        public ShowDialog()
        {
            InitializeComponent();
        }

        private void ShowDialogWithoutOwner(object sender, RoutedEventArgs e)
        {
            var window = new Window
                {
                    Width = 300,
                    Height = 300,
                    Title = "WithoutOwner",
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

            window.ShowDialog();
        }

        private void ShowDialogWithOwner(object sender, RoutedEventArgs e)
        {
            var window = new Window
                {
                    Width = 300,
                    Height = 300,
                    Title = "WithOwner",
                    Owner = this,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
            window.ShowDialog();
        }
    }
}
