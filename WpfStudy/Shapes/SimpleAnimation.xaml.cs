namespace WpfStudy.Shapes
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    /// <summary>
    /// Interaction logic for SimpleAnimation.xaml.
    /// </summary>
    public partial class SimpleAnimation
    {
        public SimpleAnimation()
        {
            InitializeComponent();
        }

        private void RotateRectOne(object sender, RoutedEventArgs e)
        {
            var rotateAnimation = new DoubleAnimation(0, 360, new Duration(new TimeSpan(0, 0, 5)), FillBehavior.Stop);

            var scaleAnimation = new DoubleAnimation(1, 2, new Duration(new TimeSpan(0, 0, 5)), FillBehavior.HoldEnd);

            var transformGroup = new TransformGroup();
            var rotateTransform = new RotateTransform();
            var scaleTransform = new ScaleTransform();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(scaleTransform);

            this.RectOne.LayoutTransform = transformGroup;

            Storyboard.SetTarget(rotateAnimation, rotateTransform);
            Storyboard.SetTarget(scaleAnimation, scaleTransform);

            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
            rotateTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
        }
    }
}
