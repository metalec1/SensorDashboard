using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace SensorDashboard.Converters;

public class BoolToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isActive = (bool)value;
        if (isActive)
        {
            return Brushes.Green;
        }
        else
        {
            return Brushes.Red;
        }

        
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}