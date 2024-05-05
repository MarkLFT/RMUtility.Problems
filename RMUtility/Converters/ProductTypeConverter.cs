using Standard.Licensing;

namespace RMUtility.Converters;
internal class ProductTypeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is ProductType productType)
        {
            return productType switch
            {
                ProductType.RM => Consts.Products.ResortManager,
                ProductType.RML => Consts.Products.ResortManagerLite,
                ProductType.Custom => Consts.Products.ResortManagerCustom,
                _ => throw new ArgumentOutOfRangeException(nameof(productType), productType, null)
            };
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is string productType)
        {
            return productType switch
            {
                Consts.Products.ResortManager => ProductType.RM,
                Consts.Products.ResortManagerLite => ProductType.RML,
                Consts.Products.ResortManagerCustom => ProductType.Custom,
                _ => throw new ArgumentOutOfRangeException(nameof(productType), productType, null)
            };
        }

        return value;
    }

}
