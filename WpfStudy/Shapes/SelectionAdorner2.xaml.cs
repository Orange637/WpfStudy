using System;
namespace WpfStudy.Shapes
{
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;


    /// <summary>
    /// Interaction logic for SelectionAdorner2.xaml.
    /// </summary>
    public partial class SelectionAdorner2
    {
        private Point startPoint;

        private bool isSelecting;

        private Resources.Controls.Adorners.SelectionAdorner2 selectionAdorner;

        public SelectionAdorner2()
        {
            this.InitializeComponent();
        }

        private void Container_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.startPoint = e.GetPosition(Container);
            this.isSelecting = true;
            e.Handled = true;
        }

        private void Container_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (this.isSelecting == false || e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            var adornerLayer = AdornerLayer.GetAdornerLayer(Container);
            if (adornerLayer != null)
            {
                if (this.selectionAdorner == null)
                {
                    this.selectionAdorner = new Resources.Controls.Adorners.SelectionAdorner2(
                        Container, this.startPoint);

                    adornerLayer.Add(this.selectionAdorner);
                }
                else
                {
                    this.selectionAdorner.Move(this.startPoint, e.GetPosition(this.selectionAdorner));
                    this.selectionAdorner.InvalidateVisual();
                }
            }
        }

        private void Container_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (this.isSelecting)
            {
                this.isSelecting = false;

                var adornerLayer = AdornerLayer.GetAdornerLayer(Container);
                adornerLayer.Remove(this.selectionAdorner);
                this.selectionAdorner = null;
            }
        }
    }
}
