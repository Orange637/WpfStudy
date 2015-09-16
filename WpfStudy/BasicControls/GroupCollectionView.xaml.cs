// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GroupCollectionView.xaml.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   Interaction logic for LiveShaping.xaml.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfStudy.BasicControls
{
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Interaction logic for LiveShaping.xaml.
    /// </summary>
    public partial class GroupCollectionView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCollectionView"/> class.
        /// </summary>
        public GroupCollectionView()
        {
            this.InitializeComponent();

            this.Processes = new ObservableCollection<Process>(Process.GetProcesses().Where(CanAccess));
            this.NotifyPropretyChanged(() => this.Processes);
        }

        public ObservableCollection<Process> Processes { get; set; }

        private static bool CanAccess(Process process)
        {
            try
            {
                var h = process.Handle;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void GroupCollection(object sender, RoutedEventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView(this.ProcessListBox.DataContext);
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(new PropertyGroupDescription("PriorityClass"));
        }
    }
}