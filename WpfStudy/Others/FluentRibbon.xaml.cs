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

namespace WpfStudy.Others
{
    using System.ComponentModel;

    /// <summary>
    /// Interaction logic for FluentRibbon.xaml
    /// </summary>
    public partial class FluentRibbon
    {
        public FluentRibbon()
        {
            InitializeComponent();
        }

        private void FluentRibbon_OnClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
