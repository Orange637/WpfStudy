namespace WpfStudy.Shapes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for SelectionAdorner.xaml.
    /// </summary>
    public partial class SelectionAdorner
    {
        private bool isMoving;

        private Adorner adorner;

        private Point currentPoint;

        private Shape currentShape;

        public SelectionAdorner()
        {
            InitializeComponent();

            this.isMoving = false;
        }

        private void CreateCircles(object sender, RoutedEventArgs e)
        {
            var random = new Random();

            foreach (var index in Enumerable.Range(0, 10))
            {
                var brushNumber = random.Next(30);

                var brush =
                    typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static)[brushNumber].GetValue(
                        null, null) as Brush;

                var circle = new Ellipse { Width = 50, Height = 50, Fill = brush, Stroke = Brushes.Black, StrokeThickness = 1 };

                Canvas.SetLeft(circle, random.NextDouble() * (this.CircleCanvas.ActualWidth - 70));
                Canvas.SetTop(circle, random.NextDouble() * (this.CircleCanvas.ActualHeight - 70));
                circle.PreviewMouseLeftButtonDown += (o, args) => MessageBox.Show("Hit Circle" + index);
                this.CircleCanvas.Children.Add(circle);
            }
        }

        private void CircleCanvas_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Console.Out.WriteLine("OnMouseLeftButtonDown");
            var layer = AdornerLayer.GetAdornerLayer(this.CircleCanvas);
            if (this.adorner != null)
            {
                layer.Remove(this.adorner);
                this.adorner = null;
            }

            var shape = e.Source as Shape;
            if (shape != null)
            {
                shape.InputHitTest(e.GetPosition(shape));
                this.isMoving = true;
                this.currentPoint = e.GetPosition(this.CircleCanvas);
                this.currentShape = shape;
                this.adorner = new Resources.Controls.Adorners.SelectionAdorner(shape);
                layer.Add(this.adorner);
                this.CircleCanvas.CaptureMouse();
            }

            e.Handled = true;
        }

        private void CircleCanvas_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.isMoving)
            {
                this.isMoving = false;
                this.CircleCanvas.ReleaseMouseCapture();
            }
        }

        private void CircleCanvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (this.isMoving)
            {
                var point = e.GetPosition(this.CircleCanvas);
                Canvas.SetLeft(this.currentShape, Canvas.GetLeft(this.currentShape) + point.X - this.currentPoint.X);
                Canvas.SetTop(this.currentShape, Canvas.GetTop(this.currentShape) + point.Y - this.currentPoint.Y);

                this.currentPoint = point;
            }

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hit Button");
        }
    }
}
