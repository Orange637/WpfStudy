// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DragAndDrop.xaml.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   Interaction logic for Window1.xaml.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfStudy.Others
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for DragAndDrop.xaml.
    /// </summary>
    public partial class DragAndDrop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DragAndDrop"/> class. 
        /// </summary>
        public DragAndDrop()
        {
            this.InitializeComponent();

            this.InitObjects();
        }

       private void InitObjects()
        {
            var rnd = new Random();
            const int CustomWidth = 45;
            const int CustomHeight = 45;
            for (int i = 0; i < 30; i++)
            {
                var shape = rnd.Next(10) > 4 ? (Shape)new Ellipse() : (Shape)new Rectangle();
                shape.Stroke = Brushes.Black;
                shape.StrokeThickness = 2;
                shape.Fill = rnd.Next(10) > 4 ? Brushes.Red : Brushes.LightBlue;
                shape.Width = CustomWidth;
                shape.Height = CustomHeight;
                Canvas.SetLeft(shape, rnd.NextDouble() * 200);
                Canvas.SetTop(shape, rnd.NextDouble() * 200);
                this.Source.Children.Add(shape);
            }
        }

        private void OnBeginDrag(object sender, MouseButtonEventArgs e)
        {
            var obj = e.Source as Shape;
            if (obj != null)
            {
                DragDrop.DoDragDrop(obj, obj, DragDropEffects.Move);
            }
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            var element = e.Data.GetData(e.Data.GetFormats()[0]) as UIElement;
            if (element != null)
            {
                this.Source.Children.Remove(element);
                this.Target.Children.Add(element);
            }
        }
    }
}