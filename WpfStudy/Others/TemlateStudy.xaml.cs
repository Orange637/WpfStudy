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
    /// <summary>
    /// Interaction logic for TemlateStudy.xaml
    /// </summary>
    public partial class TemlateStudy
    {
        public TemlateStudy()
        {
            InitializeComponent();

            this.Name = "ddddddddddddddd";
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value, () => this.Name); }
        }
        
    }
}
