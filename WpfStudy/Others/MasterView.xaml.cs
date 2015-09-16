// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasterView.xaml.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   Interaction logic for MasterView.xaml.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfStudy.Others
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Interaction logic for MasterView.xaml.
    /// </summary>
    public partial class MasterView
    {
        private readonly List<Process> processList;

        private bool sortDirection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterView"/> class.
        /// </summary>
        public MasterView()
        {
            this.InitializeComponent();

            this.processList = Process.GetProcesses().OrderBy(process => process.Id).ToList();

            this.Processs = new ObservableCollection<Process>(this.processList);
            this.NotifyPropretyChanged(() => this.Processs);

            this.processList.RemoveAt(0);
            this.NotifyPropretyChanged(() => this.Processs);
        }

        public ObservableCollection<Process> Processs { get; set; }

        public bool SortDirection
        {
            get
            {
                return this.sortDirection;
            }

            set
            {
                this.SetProperty(ref this.sortDirection, value, () => this.SortDirection);
            }
        }

       private void SortListBox(object sender, RoutedEventArgs e)
        {
            var listview = CollectionViewSource.GetDefaultView(this.ProcessListBox.DataContext);
            listview.SortDescriptions.Clear();
            listview.SortDescriptions.Add(
                new SortDescription(
                    "Id1", this.SortDirection ? ListSortDirection.Ascending : ListSortDirection.Descending));
        }

        private void FilterListBox(object sender, RoutedEventArgs e)
        {
            var listview = CollectionViewSource.GetDefaultView(this.ProcessListBox.DataContext);
            listview.Filter = null;
            listview.Filter = obj => ((Process)obj).ProcessName.Length > 8;
        }
    }
}