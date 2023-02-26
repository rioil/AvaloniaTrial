using Avalonia.Controls;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace AvaloniaTrial.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class ValueIsEvenConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is int iVal && iVal % 2 == 0;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
