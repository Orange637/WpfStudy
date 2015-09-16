namespace WpfStudy.Model
{
    using System.ComponentModel;
    using System.Windows;

    using WpfStudy.Infrastructure;

    public class ImageData : ObservableObject
    {
        private string sourcePath;

        private double zoom;

        private double angle;

        /*private double centerX;

        private double centerY;*/

        public ImageData()
        {
            this.Zoom = 1.0;

            this.Angle = 0;


            var prop = DesignerProperties.IsInDesignModeProperty;
            bool design =
                (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            if (design)
            {
                this.SourcePath =
                    @"D:\2.Picture\cnblogs\743093938516771926.jpg";
            }
        }

        public string SourcePath
        {
            get { return this.sourcePath; }
            set { this.SetProperty(ref this.sourcePath, value, () => this.SourcePath); }
        }

        public double Zoom
        {
            get { return this.zoom; }
            set { this.SetProperty(ref this.zoom, value, () => this.Zoom); }
        }

        public double Angle
        {
            get
            {
                return this.angle;
            }

            set
            {
                this.SetProperty(ref this.angle, value, () => this.Angle);
            }
        }

        /*public double CenterX
        {
            get
            {
                return this.centerX;
            }

            set
            {
                this.SetProperty(ref this.centerX, value, () => this.CenterX);
            }
        }

        public double CenterY
        {
            get
            {
                return this.centerY;
            }

            set
            {
                this.SetProperty(ref this.centerY, value, () => this.CenterY);
            }
        }*/
    }
}
