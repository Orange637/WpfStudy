using System.Runtime.InteropServices;

namespace WpfStudy.Resources.Behaviors
{
    using System.Windows;
    using System.Windows.Shapes;

    public class CustomProperty
    {
        public static readonly DependencyProperty ShowProperty = DependencyProperty.RegisterAttached(
            "Show",
            typeof(bool),
            typeof(Rectangle),
            new PropertyMetadata(
                false,
                (obj, value) =>
                    {
                        var rectangle = obj as Rectangle;
                        if (rectangle != null)
                        {
                            rectangle.MouseLeftButtonDown +=
                                (sender, arg) => { rectangle.Visibility = Visibility.Hidden; };
                        }
                    }),
            falg =>
                {
                    int i = 1;
                    return false;
                });

        public static bool GetShow(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowProperty);
        }

        public static void SetShow(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowProperty, value);
        }
    }
}
