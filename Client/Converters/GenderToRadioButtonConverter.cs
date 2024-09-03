﻿using System.Globalization;

namespace Client.Converters
{
    public class GenderToRadioButtonConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            return value.ToString()!.Equals(parameter.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return parameter.ToString();
            }

            return null;
        }
    }
}
