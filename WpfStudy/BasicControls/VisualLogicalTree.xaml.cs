// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisualLogicalTree.xaml.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   Interaction logic for VisualLogicalTree.xaml.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfStudy.BasicControls
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for VisualLogicalTree.xaml.
    /// </summary>
    public partial class VisualLogicalTree : INotifyPropertyChanged
    {
        /// <summary>
        /// The _logical root item.
        /// </summary>
        private VisualItem _logicalRootItem;

        /// <summary>
        /// The _visual root item.
        /// </summary>
        private VisualItem _visualRootItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualLogicalTree"/> class.
        /// </summary>
        public VisualLogicalTree()
        {
            this.InitializeComponent();

            this.Loaded += this.WindowLoaded;
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the logical root item.
        /// </summary>
        public VisualItem LogicalRootItem
        {
            get
            {
                return this._logicalRootItem;
            }

            set
            {
                this._logicalRootItem = value;
                this.OnPropertyChanged("LogicalRootItem");
            }
        }

        /// <summary>
        /// Gets or sets the visual root item.
        /// </summary>
        public VisualItem VisualRootItem
        {
            get
            {
                return this._visualRootItem;
            }

            set
            {
                this._visualRootItem = value;
                this.OnPropertyChanged("VisualRootItem");
            }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The window loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.LogicalRootItem = this.GetLogicalTree(this);

            this.VisualRootItem = this.GetVisualTree(this);
        }

        /// <summary>
        /// The get logical tree.
        /// </summary>
        /// <param name="root">
        /// The root.
        /// </param>
        /// <returns>
        /// The <see cref="VisualItem"/>.
        /// </returns>
        private VisualItem GetLogicalTree(DependencyObject root)
        {
            if (root == null)
            {
                return null;
            }

            var rootItem = new VisualItem(root);
            foreach (var child in LogicalTreeHelper.GetChildren(root))
            {
                var logicalChild = this.GetLogicalTree(child as DependencyObject);
                if (logicalChild != null)
                {
                    rootItem.Children.Add(logicalChild);
                }
            }

            return rootItem;
        }

        /// <summary>
        /// The get visual tree.
        /// </summary>
        /// <param name="root">
        /// The root.
        /// </param>
        /// <returns>
        /// The <see cref="VisualItem"/>.
        /// </returns>
        private VisualItem GetVisualTree(DependencyObject root)
        {
            if (root == null)
            {
                return null;
            }

            var rootItem = new VisualItem(root);
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                var subItem = this.GetVisualTree(child);
                rootItem.Children.Add(subItem);
            }

            return rootItem;
        }
    }
}