namespace WpfStudy
{
    using System;
    using System.Windows;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App
    {
        public App()
        {
            this.DispatcherUnhandledException += ApplicationDispatcherUnhandledException;

            AppDomain.CurrentDomain.UnhandledException += this.CurrentDomainUnhandledException;
        }

        private static void ApplicationDispatcherUnhandledException(
            object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                var ex = e.Exception;
                const string ErrorMsg = "UI Thread Exception : \n\n";
                MessageBox.Show("An unhandled UI Thread exception occurred" + ErrorMsg);
                e.Handled = true; 
                if (!Current.MainWindow.IsActive)
                {
                    Current.Shutdown();
                }
            }
            catch
            {
                MessageBox.Show(
                    "An unhandled exception occurred, and the application is terminating. " + Environment.NewLine
                    + "For more information, see your Application log.");
                Environment.Exit(1);
            }
        }

        private void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var ex = (Exception)e.ExceptionObject;
                const string ErrorMsg = "Non-UI Thread Exception : \n\n";
                MessageBox.Show("An unhandled Not-UI Thread exception occurred:" + ErrorMsg);
                if (!Current.MainWindow.IsActive)
                {
                    Current.Shutdown();
                }
            }
            catch
            {
                MessageBox.Show(
                    "An unhandled exception occurred, and the application is terminating. " + Environment.NewLine
                    + "For more information, see your Application log.");
                Environment.Exit(1);
            }
        }
    }
}
