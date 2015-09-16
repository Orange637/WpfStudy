using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfStudy.Resources.Controls.Adorners
{
    public class SelectionAdorner : Adorner
    {
        private const double CircleRadius = 6;

        private static readonly Pen Pen = new Pen(Brushes.Black, 1) { DashStyle = DashStyles.Dash };

        private static readonly Brush RectFill = new SolidColorBrush(Color.FromArgb(30, 0, 0, 255));

        private static readonly Brush CircleFill = new SolidColorBrush(Color.FromArgb(60, 255, 0, 0));

        public SelectionAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            this.MouseLeftButtonDown += SelectionAdorner_MouseLeftButtonDown;
            
            this.IsHitTestVisible = false;
        }

        void SelectionAdorner_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Console.Out.WriteLine("SelectionAdorner_MouseLeftButtonDown");
            var shape = ((SelectionAdorner)sender).AdornedElement as Shape;

            this.Visibility = Visibility.Collapsed;
            

            var arg = new RoutedEventArgs(MouseLeftButtonDownEvent, shape);
            var arg2 = new MouseButtonEventArgs(e.MouseDevice,e.Timestamp,e.ChangedButton){RoutedEvent = MouseLeftButtonDownEvent,Source = shape};
            shape.RaiseEvent(arg2);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(RenderSize));

            drawingContext.DrawRectangle(RectFill, Pen, new Rect(AdornedElement.DesiredSize));

            drawingContext.DrawEllipse(CircleFill, null, new Point(0, 0), CircleRadius, CircleRadius);
            drawingContext.DrawEllipse(
                CircleFill, null, new Point(AdornedElement.DesiredSize.Width, 0), CircleRadius, CircleRadius);
            drawingContext.DrawEllipse(
                CircleFill, null, new Point(0, AdornedElement.DesiredSize.Height), CircleRadius, CircleRadius);
            drawingContext.DrawEllipse(
                CircleFill,
                null,
                new Point(AdornedElement.DesiredSize.Width, AdornedElement.DesiredSize.Height),
                CircleRadius,
                CircleRadius);
        }
    }
}
