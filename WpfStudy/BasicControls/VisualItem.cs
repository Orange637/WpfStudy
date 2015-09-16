// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisualItem.cs" company="MM Software GmbH">
//   (C) by MM Software GmbH. All rights reserved.
// </copyright>
// <summary>
//   The visual item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfStudy.BasicControls
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Media;

    /// <summary>
    /// The visual item.
    /// </summary>
    public class VisualItem : INotifyPropertyChanged
    {
        /// <summary>
        /// The _target.
        /// </summary>
        private readonly object target;

        /// <summary>
        /// The _children.
        /// </summary>
        private readonly ObservableCollection<VisualItem> children = new ObservableCollection<VisualItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualItem"/> class.
        /// </summary>
        /// <param name="visual">
        /// The visual.
        /// </param>
        public VisualItem(object visual)
        {
            this.target = visual;
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the children.
        /// </summary>
        public ObservableCollection<VisualItem> Children
        {
            get
            {
                return this.children;
            }
        }

        /// <summary>
        /// Gets the target.
        /// </summary>
        public object Target
        {
            get
            {
                return this.target;
            }
        }

        /// <summary>
        /// Gets the visual brush.
        /// </summary>
        public VisualBrush VisualBrush
        {
            get
            {
                if (this.target is Visual)
                {
                    return new VisualBrush(target as Visual) { Stretch = Stretch.Uniform };
                }

                return null;
            }
        }

        public override string ToString()
        {
            return string.Format("Type:{0},Value:{1}", this.Target.GetType().Name, this.target);
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
    }
}