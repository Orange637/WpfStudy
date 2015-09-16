namespace WpfStudy.Commands
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// ImageScroll.xaml 的交互逻辑
    /// </summary>
    public partial class ImageScroll
    {
        ShapeImageScroll Scroll = null;
        Brush tempImage = null;
        /// <summary>
        /// 主要功能为可以图片的流动大小变化，与拖动功能！！
        /// </summary>
        public ImageScroll()
        {
            this.InitializeComponent();
            //
            this.Scroll = new ShapeImageScroll(this.RectTest);
        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Tag.ToString())
            {
                case "OpenFile":
                    //添加显示的图片。
                    Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog();
                    file.Filter = "*.jpg|*.jpg|*.bmp|*.bmp|*.gif|*.gif|*.png|*.png";
                    file.ShowDialog();
                    this.ImgInfo.Source = new BitmapImage(new Uri(file.FileName));
                    break;
                case "InitImage":
                    //图片重置大小。
                    ScaleTransform scale = this.Scroll.GetTransFormGroup().Children[0] as ScaleTransform;
                    scale.ScaleX = 1;
                    scale.ScaleY = 1;
                    break;
                case "OcrKnow":
                    //调用一个exe程序的方面实现。
                    this.Execute(this.ImgInfo.Source.ToString());
                    break;
                case "SaveText":
                    this.SaveText();
                    break;
                case "RotateTransform":
                    //图片旋转90度的。
                    this.Scroll.DoImageRotate();
                    break;
                case "AboutBox":
                    MessageBox.Show("AboutBox");
                    break;
            }
        }
        private void SaveText()
        {
        }
        private void Execute(string ImagePath)
        {
            /*string textPath = Guid.NewGuid().ToString();
            ProcessStartInfo info = new ProcessStartInfo();
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            //文件夹路径。
            info.WorkingDirectory = @"E:\dd";
            //传值参数的的数值。
            info.Arguments = string.Format(" {0} {1} ", @"e:\dd\eurotext.tif", textPath);
            info.FileName = @"tesseract.exe";
            using (Process subProcess = new Process())
            {
                subProcess.StartInfo = info;
                subProcess.Start();
                subProcess.WaitForExit(int.MaxValue);
            }
            //
            textPath = @"E:\dd\" + textPath + ".txt";
            FileStream fs = new FileStream(textPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            this.txtShow.Text = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            File.Delete(textPath);*/
        }
    }
    /// <summary>
    /// 只能用在Grid才可以加载Rectangle,Ellipse效果。【鼠标的拖动与滚轮图片放大】
    /// </summary>
    public class ShapeImageScroll
    {
        /// <summary>
        /// 判断鼠标是否按下状态。
        /// </summary>
        private bool IsMouseLeftButtonDown = false;
        /// <summary>
        /// 记录不上一次的鼠标坐标是。
        /// </summary>
        private Point ShapeMousePoint;
        /// <summary>
        /// 变形的指定对象。
        /// </summary>
        public Shape shape;
        /// <summary>
        /// 初始化方法.
        /// </summary>
        /// <param name="shape">Shape图形对象</param>
        /// <param name="mainPanel">Grid的主窗体对象</param>
        public ShapeImageScroll(Shape shape)
        {
            //添加变形效果资源.
            this.shape = shape;
            TransformGroup group = new TransformGroup();
            group.Children.Add(new ScaleTransform());
            group.Children.Add(new TranslateTransform());
            group.Children.Add(new RotateTransform());
            shape.MouseLeftButtonDown += new MouseButtonEventHandler(this.shape_MouseLeftButtonDown);
            shape.MouseLeftButtonUp += new MouseButtonEventHandler(this.shape_MouseLeftButtonUp);
            shape.MouseMove += new MouseEventHandler(this.shape_MouseMove);
            shape.MouseWheel += new MouseWheelEventHandler(this.shape_MouseWheel);
            shape.Fill.Transform = group;
        }
        /// <summary>
        /// 取得对应的变化的资源信息.
        /// </summary>
        /// <returns></returns>
        public TransformGroup GetTransFormGroup()
        {
            return this.shape.Fill.Transform as TransformGroup;
        }
        /// <summary>
        /// 执行拖动移位功能.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="e"></param>
        private void DoImageMove(Shape shape, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            TransformGroup group = this.GetTransFormGroup() as TransformGroup;
            TranslateTransform transform = group.Children[1] as TranslateTransform;
            RotateTransform rotate = group.Children[2] as RotateTransform;
            Point position = e.GetPosition(shape);
            //判断不同角度需要的移动距离各不相同。
            double overAngle = rotate.Angle % 360;
            if (overAngle == 0)
            {
                transform.X += position.X - this.ShapeMousePoint.X;
                transform.Y += position.Y - this.ShapeMousePoint.Y;
                this.ShapeMousePoint = position;
                return;
            }
            if (overAngle == 90)
            {
                transform.X += position.Y - this.ShapeMousePoint.Y;
                transform.Y += -(position.X - this.ShapeMousePoint.X);
                this.ShapeMousePoint = position;
                return;
            }
            if (overAngle == 180)
            {
                transform.X -= -(this.ShapeMousePoint.X - position.X);
                transform.Y -= -(this.ShapeMousePoint.Y - position.Y);
                this.ShapeMousePoint = position;
                return;
            }
            if (overAngle == 270)
            {
                transform.X += this.ShapeMousePoint.Y - position.Y;
                transform.Y += -(this.ShapeMousePoint.X - position.X);
                this.ShapeMousePoint = position;
                return;
            }
        }
        /// <summary>
        /// 对图片进行90旋转操作用。
        /// </summary>
        public void DoImageRotate()
        {
            RotateTransform rotate = this.GetTransFormGroup().Children[2] as RotateTransform;
            rotate.Angle += 90;
            rotate.CenterX = this.shape.ActualWidth / 2;
            rotate.CenterY = this.shape.ActualHeight / 2;
        }
        #region===============响应的事件【拖动实现用。】==================
        void shape_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            TransformGroup group = this.GetTransFormGroup() as TransformGroup;
            ScaleTransform transform = group.Children[0] as ScaleTransform;
            transform.ScaleX += e.Delta * 0.001;
            transform.ScaleY += e.Delta * 0.001;
            transform.CenterX = this.shape.ActualWidth / 2;
            transform.CenterY = this.shape.ActualHeight / 2;
        }
        void shape_MouseMove(object sender, MouseEventArgs e)
        {
            Shape shape = sender as Shape;
            if (shape == null) return;
            if (this.IsMouseLeftButtonDown)
                this.DoImageMove(shape, e);
        }
        void shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Shape shape = sender as Shape;
            if (shape == null) return;
            shape.ReleaseMouseCapture();
            this.IsMouseLeftButtonDown = false;
        }
        void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Shape shape = sender as Shape;
            if (shape == null) return;
            shape.CaptureMouse();
            this.IsMouseLeftButtonDown = true;
            this.ShapeMousePoint = e.GetPosition(shape);
        }
        #endregion
    }
}