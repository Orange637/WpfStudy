namespace WpfStudy.Resources.Controls
{
    using System.Collections;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;

    public class ContentAdorner : Adorner
    {
        private readonly FrameworkElement child;

        public ContentAdorner(FrameworkElement adornedElement, FrameworkElement adornedContent)
            : base(adornedElement)
        {
            this.child = adornedContent;

            adornedElement.SizeChanged += (_, __) => this.InvalidateMeasure();

            this.AddLogicalChild(this.child);
            this.AddVisualChild(this.child);
        }

        public new FrameworkElement AdornedElement
        {
            get
            {
                return (FrameworkElement)base.AdornedElement;
            }
        }

        protected override IEnumerator LogicalChildren
        {
            get
            {
                var list = new ArrayList { this.child };
                return list.GetEnumerator();
            }
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        public void DisconnectChild()
        {
            this.RemoveLogicalChild(this.child);
            this.RemoveVisualChild(this.child);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            this.child.Arrange(new Rect(0, 0, this.AdornedElement.ActualWidth, this.AdornedElement.ActualHeight));

            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return this.child;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            this.child.Measure(constraint);
            return this.child.DesiredSize;
        }
    }
}