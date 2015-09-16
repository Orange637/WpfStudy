namespace Resource.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class BreakPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                MessageBox.Show("Value is null!");
            }

            if (targetType != null)
            {
                MessageBox.Show(string.Format("{0} is targetType!", targetType.FullName));
            }



            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
