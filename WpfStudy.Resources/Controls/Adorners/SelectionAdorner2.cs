namespace WpfStudy.Resources.Controls.Adorners
{
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;

    using Brush = System.Windows.Media.Brush;
    using Brushes = System.Windows.Media.Brushes;
    using Pen = System.Windows.Media.Pen;

    public class SelectionAdorner2 : Adorner
    {
        private static readonly Brush SelectionBackgound = new SolidColorBrush(Color.FromArgb(0x5f, 0x33, 0x99, 0xff));

        private static readonly Pen SelectionBorder = new Pen(new SolidColorBrush(Color.FromRgb(0x33, 0x99, 0xff)), 1);

        private Point startPoint;

        private Point endPoint;

        public SelectionAdorner2(UIElement adornedElement, Point start)
            : base(adornedElement)
        {
            this.startPoint = start;

            this.MouseMove += this.SelectionAdorner2MouseMove;
            this.MouseUp += this.SelectionAdorner2MouseUp;
        }

        public void Move(Point start, Point end)
        {
            this.startPoint = start;
            this.endPoint = end;
            this.InvalidateVisual();
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            // drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(RenderSize));
            drawingContext.DrawRectangle(SelectionBackgound, SelectionBorder, new Rect(this.startPoint, this.endPoint));
        }

        private void SelectionAdorner2MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var adornerLayer = this.Parent as AdornerLayer;
            if (adornerLayer != null)
            {
                adornerLayer.Remove(this);
            }

            e.Handled = true;
        }

        private void SelectionAdorner2MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.endPoint = e.GetPosition(this);
            this.InvalidateVisual();
            e.Handled = true;
        }
    }
}
