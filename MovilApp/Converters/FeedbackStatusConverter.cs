using System.Globalization;

namespace MovilApp.Converters
{
    public class FeedbackColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool feedbackRecibido)
            {
                return feedbackRecibido ? Color.FromArgb("#22c55e") : Color.FromArgb("#f59e0b");
            }
            return Color.FromArgb("#6b7280");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

    public class FeedbackTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool feedbackRecibido)
            {
                // CORRECCIÓN: Se eliminaron los signos '?'
                return feedbackRecibido ? "Recibido" : "Pendiente";
            }
            return "Sin Estado";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

    // El resto de conversores se mantienen igual pero sin arrojar errores...
    public class StringNotEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is string str && !string.IsNullOrEmpty(str);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

    public class StringNotNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is string str && !string.IsNullOrWhiteSpace(str);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is bool boolValue && !boolValue;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value is bool boolValue && !boolValue;
    }
}