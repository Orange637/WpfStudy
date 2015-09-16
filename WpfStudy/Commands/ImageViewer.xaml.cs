namespace WpfStudy.Commands
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;
    using Microsoft.Win32;
    using WpfStudy.Model;

    public partial class ImageViewer
    {
        private ImageData image;

        private ICommand resetCommand;

        public ImageViewer()
        {
            this.InitializeComponent();

            this.ImageData = new ImageData();

            this.ResetCommand = new ResetCommand(this.image);
        }

        public ImageData ImageData
        {
            get { return this.image; }
            set { this.SetProperty(ref this.image, value, () => this.ImageData); }
        }

        public ICommand ResetCommand
        {
            get
            {
                return this.resetCommand;
            }

            set
            {
                this.SetProperty(ref this.resetCommand, value, () => this.ResetCommand);
            }
        }

        private void OpenImageFile(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
                             {
                                 Filter = "Image Files|*.jpg;*.png;*.bmp;*.gif",
                                 InitialDirectory = @"D:\2.Picture"
                             };

            if (dialog.ShowDialog(this) == true)
            {
                this.ImageData.SourcePath = dialog.FileName;
                this.ImageData.Angle = 0;
                this.ImageData.Zoom = 1.0;
            }
        }

        private void ZoomIn(object sender, ExecutedRoutedEventArgs e)
        {
            this.ImageData.Zoom *= 2;
        }

        private void ZoomOut(object sender, ExecutedRoutedEventArgs e)
        {
            this.ImageData.Zoom /= 2;
        }

        private void OnIsImageExist(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ImageData != null && File.Exists(this.ImageData.SourcePath);
        }

        private void ResetZoom(object sender, ExecutedRoutedEventArgs e)
        {
            this.ImageData.Zoom = 1.0;
        }

        private void FitZoom(object sender, ExecutedRoutedEventArgs e)
        {
            var height = this.ImageScroll.ActualHeight;
            var width = this.ImageScroll.ActualWidth;

            var imageHeight = ImageFile.ActualHeight * this.ImageData.Zoom;
            var imageWidth = ImageFile.ActualWidth * this.ImageData.Zoom;

            var zoomRadio = Math.Min(height / imageHeight, width / imageWidth);

            this.ImageData.Zoom *= zoomRadio;
        }

        private void RotateLeft(object sender, ExecutedRoutedEventArgs e)
        {
            this.ImageData.Angle -= 90;
        }

        private void RotateRight(object sender, ExecutedRoutedEventArgs e)
        {
            this.ImageData.Angle += 90;
        }
    }
}
