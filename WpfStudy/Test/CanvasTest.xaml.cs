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

namespace WpfStudy.Test
{
    /// <summary>
    /// Interaction logic for CanvasTest.xaml
    /// </summary>
    public partial class CanvasTest : Window
    {
        public CanvasTest()
        {
            InitializeComponent();

            this.Image1.Source = new BitmapImage(new Uri(@"D:\2.Picture\collection\Default.jpg"));
        }
    }
}
