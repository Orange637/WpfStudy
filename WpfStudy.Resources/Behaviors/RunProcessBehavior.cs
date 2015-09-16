namespace WpfStudy.Resources.Behaviors
{
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interactivity;

    public class RunProcessBehavior : Behavior<FrameworkElement>
    {
        public string Program { get; set; }

        public string Arguments { get; set; }

        protected override void OnAttached()
        {
            this.AssociatedObject.MouseLeftButtonDown += this.OnClick;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.MouseLeftButtonDown -= this.OnClick;
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(this.Program, this.Arguments);
        }
    }
}
