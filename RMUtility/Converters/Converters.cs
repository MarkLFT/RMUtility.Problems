namespace RMUtility.Converters;
internal class Converters
{
    public static readonly IValueConverter ProductTypeConverter = new ProductTypeConverter();
    public static readonly IValueConverter LicenseTypeConverter = new LicenseTypeConverter();
    public static readonly IValueConverter DateTimeOffsetConverter = new DateTimeOffsetConverter();
    public static readonly IValueConverter StringBoolConverter = new StringBoolConverter();
}
