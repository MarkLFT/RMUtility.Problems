namespace RMUtility.Converters;
internal class StringBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is String valueString)
        {
            return valueString.Equals("true", StringComparison.InvariantCultureIgnoreCase);
        }

        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is bool boolValue)
        {
            return boolValue switch
            {
                true => "true",
                _ => "false"
            };
        }

        return "false";
    }

}
