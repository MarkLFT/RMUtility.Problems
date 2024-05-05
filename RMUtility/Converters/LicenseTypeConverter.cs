using Standard.Licensing;
using static RMUtility.Infrastructure.Consts;

namespace RMUtility.Converters;

internal class LicenseTypeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is LicenseType licenseType)
        {
            return licenseType switch
            {
                LicenseType.None => Consts.LicenseTypes.None,
                LicenseType.Trial => Consts.LicenseTypes.Trial,
                LicenseType.Full => Consts.LicenseTypes.Full,
                LicenseType.Error => Consts.LicenseTypes.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is string licenseType)
        {
            return licenseType switch
            {
                Consts.LicenseTypes.None => LicenseTypes.None,
                Consts.LicenseTypes.Trial => LicenseTypes.Trial,
                Consts.LicenseTypes.Full => LicenseTypes.Full,
                Consts.LicenseTypes.Error => LicenseTypes.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        return value;
    }

}
