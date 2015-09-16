using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfStudy.Resources.Behaviors
{
    public class FocusService
    {
        public static readonly DependencyProperty CanGetFocusedProperty =
            DependencyProperty.RegisterAttached(
                "CanGetFocused",
                typeof(bool),
                typeof(FocusService),
                new PropertyMetadata(
                    false,
                    (sender, args) =>
                        {
                            if (sender is Panel)
                            {
                                var foucsedElement = sender as Panel;
                                if ((bool)args.NewValue)
                                {
                                    foucsedElement.MouseLeftButtonDown += FocusedElement_MouseLeftButtonDown;
                                    if (foucsedElement.Background == null)
                                    {
                                        foucsedElement.Background = Brushes.Transparent;
                                    }

                                    foucsedElement.Focusable = true;
                                    foucsedElement.FocusVisualStyle = null;
                                }
                                else
                                {
                                    foucsedElement.MouseLeftButtonDown -= FocusedElement_MouseLeftButtonDown;
                                }
                            }

                            if (sender is Control)
                            {
                                var foucsedElement = sender as Control;
                                if ((bool)args.NewValue)
                                {
                                    foucsedElement.MouseLeftButtonDown += FocusedElement_MouseLeftButtonDown;
                                    if (foucsedElement.Background == null)
                                    {
                                        foucsedElement.Background = Brushes.Transparent;
                                    }

                                    foucsedElement.Focusable = true;
                                    foucsedElement.FocusVisualStyle = null;
                                }
                                else
                                {
                                    foucsedElement.MouseLeftButtonDown -= FocusedElement_MouseLeftButtonDown;
                                    foucsedElement.Focusable = false;
                                }
                            }
                        }));

        public static bool GetCanGetFocused(DependencyObject obj)
        {
            return (bool)obj.GetValue(CanGetFocusedProperty);
        }

        public static void SetCanGetFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(CanGetFocusedProperty, value);
        }

        private static void FocusedElement_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Panel)
            {
                var focusedElement = sender as Panel;
                if (focusedElement.Focus())
                {
                    e.Handled = true;
                }
            }
            else if(sender is Control)
            {
                var focusedElement = sender as Control;
                if (focusedElement.Focus())
                {
                    e.Handled = true;
                }
            }
        }
    }
}
