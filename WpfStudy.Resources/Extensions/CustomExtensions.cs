namespace WpfStudy.Resources.Extensions
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Threading;

    public static class CustomExtensions
    {
        public static IList<T> FindChildElements<T>(this DependencyObject reference) where T : FrameworkElement
        {
            var childList = new List<T>();

            for (var index = 0; index < VisualTreeHelper.GetChildrenCount(reference); index++)
            {
                var child = VisualTreeHelper.GetChild(reference, index);
                if (child is T)
                {
                    childList.Add((T)child);
                }

                childList.AddRange(child.FindChildElements<T>());
            }

            return childList;
        }

        public static T FindChildElement<T>(this DependencyObject reference, string targetName)
            where T : FrameworkElement
        {
            for (var index = 0; index < VisualTreeHelper.GetChildrenCount(reference); index++)
            {
                var child = VisualTreeHelper.GetChild(reference, index);

                if (child is T && ((T)child).Name.Equals(targetName ?? string.Empty))
                {
                    return (T)child;
                }

                var grandChild = child.FindChildElement<T>(targetName);
                if (grandChild != null)
                {
                    return grandChild;
                }
            }

            return null;
        }

        public static T FindAncestorElement<T>(this DependencyObject reference, string targetName = null)
            where T : FrameworkElement
        {
            var parent = VisualTreeHelper.GetParent(reference);

            while (parent != null)
            {
                if (parent is T && (targetName == null || targetName.Equals(((T)parent).Name)))
                {
                    return (T)parent;
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }
    }
}
