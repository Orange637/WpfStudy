// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeView.xaml.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   Interaction logic for TreeView.xaml.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfStudy.BasicControls
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Interaction logic for TreeView.xaml.
    /// </summary>
    public partial class TreeView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeView"/> class.
        /// </summary>
        public TreeView()
        {
            this.InitializeComponent();

            this.Processes = Process.GetProcesses().ToList();
            this.NotifyPropretyChanged(() => this.Processes);
        }

        public List<Process> Processes { get; set; } 
    }
}