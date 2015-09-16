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

namespace WpfStudy.BasicControls
{
    /// <summary>
    /// Interaction logic for TextBoxCanLostFocus.xaml
    /// </summary>
    public partial class TextBoxCanLostFocus : Window
    {
        public TextBoxCanLostFocus()
        {
            InitializeComponent();
        }

        private void GetFocused(object sender, MouseButtonEventArgs e)
        {
            if (this.GetFocusContainer.Focus())
            {
                e.Handled = true;
            }

            base.OnMouseLeftButtonDown(e);
        }
    }
}
