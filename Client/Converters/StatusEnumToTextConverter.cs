using Client.ViewModels;
using System.Globalization;

namespace Client.Converters
{
    public class StatusEnumToTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not ValidationStatusEnum status)
            {
                return string.Empty;
            }

            return status switch
            {
                ValidationStatusEnum.Valid => Colors.Green,
                ValidationStatusEnum.InValid => Colors.Red,
                _ => Colors.Yellow,
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
