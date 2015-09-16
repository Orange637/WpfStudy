namespace WpfStudy.Behaviors
{
    using System.Windows;
    using System.Windows.Controls;

    using WpfStudy.Resources.Extensions;

    /// <summary>
    /// Interaction logic for VisualTreeStudy.xaml.
    /// </summary>
    public partial class VisualTreeStudy
    {
        public VisualTreeStudy()
        {
            InitializeComponent();
        }

        private void FindChildControlsInFristGrid(object sender, RoutedEventArgs e)
        {
            var result = this.FirstGrid.FindChildElements<TextBlock>();

            MessageBox.Show(result.Count.ToString());
        }

        private void FindChildControlsInFristGridByName(object sender, RoutedEventArgs e)
        {
            var targetName = this.TargetTextBox.Text;

            var result = this.FirstGrid.FindChildElement<FrameworkElement>(targetName);

            MessageBox.Show(result == null ? "Not Found!" : result.Name);
        }

        private void FindAncestorControlsFormTextBox(object sender, RoutedEventArgs e)
        {
            var targetName = TargetNameCheckBox.IsChecked == true ? TargetParentTextBox.Text : null;

            var result = this.TextBlock1.FindAncestorElement<Window>(targetName);

            MessageBox.Show(result == null ? "Not Found!" : result.Name);

            // MessageBox.Show(Application.Current.StartupUri.ToString());
        }
    }
}
