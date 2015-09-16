namespace WpfStudy.Resources.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class FileNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.ToString().Split(".".ToCharArray())[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
