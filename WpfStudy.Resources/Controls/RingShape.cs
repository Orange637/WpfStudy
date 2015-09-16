namespace WpfStudy.Resources.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public class RingShape : Shape
    {
        private Rect rect;

        public static readonly DependencyProperty RingWidthProperty = DependencyProperty.Register(
            "RingWidth",
            typeof(double),
            typeof(RingShape),
            new FrameworkPropertyMetadata(0.1, FrameworkPropertyMetadataOptions.AffectsRender));

        public RingShape()
        {
            if (
                !(bool)
                 DependencyPropertyDescriptor.FromProperty(
                     DesignerProperties.IsInDesignModeProperty, typeof(FrameworkElement)).Metadata.DefaultValue)
            {
                StretchProperty.OverrideMetadata(
                    typeof(RingShape),
                    new FrameworkPropertyMetadata(
                        Stretch.Uniform,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
            }
        }

        public double RingWidth
        {
            get
            {
                return (double)this.GetValue(RingWidthProperty);
            }

            set
            {
                this.SetValue(RingWidthProperty, value);
            }
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                if (this.rect.IsEmpty)
                {
                    return Geometry.Empty;
                }

                var rect2 = this.rect;
                rect2.Inflate(-this.RingWidth * this.rect.Width, -this.RingWidth * this.Height);

                return new CombinedGeometry(
                    GeometryCombineMode.Exclude, new EllipseGeometry(this.rect), new EllipseGeometry(rect2));
            }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if (double.IsInfinity(constraint.Width) || double.IsInfinity(constraint.Height))
            {
                this.rect = Rect.Empty;
                return Size.Empty;
            }

            double size;
            switch (this.Stretch)
            {
                case Stretch.Fill:
                    this.rect = new Rect(constraint);
                    break;
                case Stretch.Uniform:
                    size = Math.Min(constraint.Width, constraint.Height);
                    this.rect = new Rect(new Size(size, size));
                    break;
                case Stretch.UniformToFill:
                    size = Math.Max(constraint.Width, constraint.Height);
                    this.rect = new Rect(new Size(size, size));
                    break;
                case Stretch.None:
                    rect = double.IsNaN(constraint.Width) || double.IsNaN(constraint.Height)
                               ? Rect.Empty
                               : new Rect(new Size(constraint.Width, constraint.Height));
                    break;
            }

            return this.rect.Size;
        }
    }
}
