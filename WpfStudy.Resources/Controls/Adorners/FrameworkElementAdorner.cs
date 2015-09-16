// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameworkElementAdorner.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   The framework element adorner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AdornedControl
{
    using System;
    using System.Collections;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;


    /// <summary>
    /// Specifies the placement of the adorner in related to the adorned control.
    /// </summary>
    public enum AdornerPlacement
    {
        /// <summary>
        /// The inside.
        /// </summary>
        Inside,

        /// <summary>
        /// The outside.
        /// </summary>
        Outside
    }

    /// <summary>
    /// The framework element adorner.
    /// </summary>
    public class FrameworkElementAdorner : Adorner
    {
        /// <summary>
        /// The child.
        /// </summary>
        private readonly FrameworkElement child;

        /// <summary>
        /// The horizontal adorner placement.
        /// </summary>
        private AdornerPlacement horizontalAdornerPlacement = AdornerPlacement.Outside;

        /// <summary>
        /// The vertical adorner placement.
        /// </summary>
        private AdornerPlacement verticalAdornerPlacement = AdornerPlacement.Inside;

        private double offsetX = 0.0;

        private double offsetY = 0.0;

        private double positionX = double.NaN;

        private double positionY = double.NaN;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameworkElementAdorner"/> class.
        /// </summary>
        /// <param name="adornerChildElement">
        /// The adorner child element.
        /// </param>
        /// <param name="adornedElement">
        /// The adorned element.
        /// </param>
        public FrameworkElementAdorner(FrameworkElement adornedElement,FrameworkElement adornerChildElement)
            : base(adornedElement)
        {
            this.child = adornerChildElement;

            this.AddLogicalChild(adornerChildElement);
            this.AddVisualChild(adornerChildElement);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameworkElementAdorner"/> class.
        /// </summary>
        /// <param name="adornerChildElement">
        /// The adorner child element.
        /// </param>
        /// <param name="adornedElement">
        /// The adorned element.
        /// </param>
        /// <param name="horizontalAdornerPlacement">
        /// The horizontal adorner placement.
        /// </param>
        /// <param name="verticalAdornerPlacement">
        /// The vertical adorner placement.
        /// </param>
        /// <param name="offsetX">
        /// The offset x.
        /// </param>
        /// <param name="offsetY">
        /// The offset y.
        /// </param>
        public FrameworkElementAdorner(
            FrameworkElement adornerChildElement, 
            FrameworkElement adornedElement, 
            AdornerPlacement horizontalAdornerPlacement, 
            AdornerPlacement verticalAdornerPlacement, 
            double offsetX, 
            double offsetY)
            : base(adornedElement)
        {
            this.child = adornerChildElement;
            this.horizontalAdornerPlacement = horizontalAdornerPlacement;
            this.verticalAdornerPlacement = verticalAdornerPlacement;
            this.offsetX = offsetX;
            this.offsetY = offsetY;

            adornedElement.SizeChanged += new SizeChangedEventHandler(this.adornedElement_SizeChanged);

            this.AddLogicalChild(adornerChildElement);
            this.AddVisualChild(adornerChildElement);
        }

        /// <summary>
        /// Event raised when the adorned control's size has changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void adornedElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.InvalidateMeasure();
        }

        // Position of the child (when not set to NaN).
        /// <summary>
        /// Gets or sets the position x.
        /// </summary>
        /// <value>
        /// The position x.
        /// </value>
        public double PositionX
        {
            get
            {
                return this.positionX;
            }

            set
            {
                this.positionX = value;
            }
        }

        /// <summary>
        /// Gets or sets the position y.
        /// </summary>
        /// <value>
        /// The position y.
        /// </value>
        public double PositionY
        {
            get
            {
                return this.positionY;
            }

            set
            {
                this.positionY = value;
            }
        }

        /// <summary>
        /// The measure override.
        /// </summary>
        /// <param name="constraint">
        /// The constraint.
        /// </param>
        /// <returns>
        /// The <see cref="Size"/>.
        /// </returns>
        protected override Size MeasureOverride(Size constraint)
        {
            this.child.Measure(constraint);
            return this.child.DesiredSize;
        }

        /// <summary>
        /// Determine the X coordinate of the child.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        private double DetermineX()
        {
            switch (this.child.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        if (this.horizontalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            return -this.child.DesiredSize.Width + this.offsetX;
                        }
                        else
                        {
                            return this.offsetX;
                        }
                    }

                case HorizontalAlignment.Right:
                    {
                        if (this.horizontalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            double adornedWidth = this.AdornedElement.ActualWidth;
                            return adornedWidth + this.offsetX;
                        }
                        else
                        {
                            double adornerWidth = this.child.DesiredSize.Width;
                            double adornedWidth = this.AdornedElement.ActualWidth;
                            double x = adornedWidth - adornerWidth;
                            return x + this.offsetX;
                        }
                    }

                case HorizontalAlignment.Center:
                    {
                        double adornerWidth = this.child.DesiredSize.Width;
                        double adornedWidth = this.AdornedElement.ActualWidth;
                        double x = (adornedWidth / 2) - (adornerWidth / 2);
                        return x + this.offsetX;
                    }

                case HorizontalAlignment.Stretch:
                    {
                        return 0.0;
                    }
            }

            return 0.0;
        }

        /// <summary>
        /// Determine the Y coordinate of the child.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        private double DetermineY()
        {
            switch (this.child.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        if (this.verticalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            return -this.child.DesiredSize.Height + this.offsetY;
                        }
                        else
                        {
                            return this.offsetY;
                        }
                    }

                case VerticalAlignment.Bottom:
                    {
                        if (this.verticalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            double adornedHeight = this.AdornedElement.ActualHeight;
                            return adornedHeight + this.offsetY;
                        }
                        else
                        {
                            double adornerHeight = this.child.DesiredSize.Height;
                            double adornedHeight = this.AdornedElement.ActualHeight;
                            double x = adornedHeight - adornerHeight;
                            return x + this.offsetY;
                        }
                    }

                case VerticalAlignment.Center:
                    {
                        double adornerHeight = this.child.DesiredSize.Height;
                        double adornedHeight = this.AdornedElement.ActualHeight;
                        double x = (adornedHeight / 2) - (adornerHeight / 2);
                        return x + this.offsetY;
                    }

                case VerticalAlignment.Stretch:
                    {
                        return 0.0;
                    }
            }

            return 0.0;
        }

        /// <summary>
        /// Determine the width of the child.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        private double DetermineWidth()
        {
            if (!double.IsNaN(this.PositionX))
            {
                return this.child.DesiredSize.Width;
            }

            switch (this.child.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        return this.child.DesiredSize.Width;
                    }

                case HorizontalAlignment.Right:
                    {
                        return this.child.DesiredSize.Width;
                    }

                case HorizontalAlignment.Center:
                    {
                        return this.child.DesiredSize.Width;
                    }

                case HorizontalAlignment.Stretch:
                    {
                        return this.AdornedElement.ActualWidth;
                    }
            }

            return 0.0;
        }

        /// <summary>
        /// Determine the height of the child.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        private double DetermineHeight()
        {
            if (!double.IsNaN(this.PositionY))
            {
                return this.child.DesiredSize.Height;
            }

            switch (this.child.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        return this.child.DesiredSize.Height;
                    }

                case VerticalAlignment.Bottom:
                    {
                        return this.child.DesiredSize.Height;
                    }

                case VerticalAlignment.Center:
                    {
                        return this.child.DesiredSize.Height;
                    }

                case VerticalAlignment.Stretch:
                    {
                        return this.AdornedElement.ActualHeight;
                    }
            }

            return 0.0;
        }

        /// <summary>
        /// The arrange override.
        /// </summary>
        /// <param name="finalSize">
        /// The final size.
        /// </param>
        /// <returns>
        /// The <see cref="Size"/>.
        /// </returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = this.PositionX;
            if (double.IsNaN(x))
            {
                x = this.DetermineX();
            }

            double y = this.PositionY;
            if (double.IsNaN(y))
            {
                y = this.DetermineY();
            }

            double adornerWidth = this.DetermineWidth();
            double adornerHeight = this.DetermineHeight();
            this.child.Arrange(new Rect(x, y, adornerWidth, adornerHeight));
            return finalSize;
        }

        /// <summary>
        /// Gets the visual children count.
        /// </summary>
        /// <value>
        /// The visual children count.
        /// </value>
        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// The get visual child.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="Visual"/>.
        /// </returns>
        protected override Visual GetVisualChild(int index)
        {
            return this.child;
        }

        /// <summary>
        /// Gets the logical children.
        /// </summary>
        /// <value>
        /// The logical children.
        /// </value>
        protected override IEnumerator LogicalChildren
        {
            get
            {
                ArrayList list = new ArrayList();
                list.Add(this.child);
                return (IEnumerator)list.GetEnumerator();
            }
        }

        /// <summary>
        /// Disconnect the child element from the visual tree so that it may be reused later.
        /// </summary>
        public void DisconnectChild()
        {
            this.RemoveLogicalChild(this.child);
            this.RemoveVisualChild(this.child);
        }

        /// <summary>
        /// Override AdornedElement from base class for less type-checking.
        /// </summary>
        /// <value>
        /// The adorned element.
        /// </value>
        public new FrameworkElement AdornedElement
        {
            get
            {
                return (FrameworkElement)base.AdornedElement;
            }
        }
    }
}