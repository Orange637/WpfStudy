﻿namespace WpfStudy.Resources.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
