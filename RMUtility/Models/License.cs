using Standard.Licensing;
using Customer = RMUtility.Models.Customer;
using LicenseType = Standard.Licensing.LicenseType;

namespace RMUtility.Business.Models;

public partial class License
{
    public License() { }

    public License(Guid serial, Customer customer, DateTime expiresDate, List<Feature> features, LicenseType licenseType, LicenseOptions options, ProductType productType, string allowedVersion) : this()
    {
        Serial = serial;
        Customer = customer;
        ExpiresDate = expiresDate;
        Features = features;
        LicenseType = licenseType;
        Options = options;
        ProductType = productType;
        AllowedVersion = allowedVersion;
    }

    public Guid Serial { get; private set; }
    public Customer? Customer { get; private set; }
    public DateTime ExpiresDate { get; private set; }
    public List<Feature>? Features { get; private set; }
    public LicenseType LicenseType { get; private set; }
    public LicenseOptions? Options { get; private set; }
    public ProductType ProductType { get; private set; }
    public string? AllowedVersion { get; private set; }

    public string Company => Customer!.CustomerName!;
    public string Name => Customer!.Name!;
    public string Email => Customer!.EmailAddress!;
    public string ProductTypeName => GetProductTypeName(ProductType);
    public string LicenseTypeName => GetLicenseTypeName(LicenseType);
    public void ExtendLicense(DateTime newExpiresDate)
    {
        ExpiresDate = newExpiresDate;
    }

    public static License NewLicense()
    {
        return new License
        (
            Guid.NewGuid(),
            new Customer(),
            DateTime.Today.AddYears(1),
            [],
            LicenseType.Trial,
            new LicenseOptions(),
            ProductType.RM,
            "9.9.9000"
        );
    }

    #region Private Helpers
    private static string GetProductTypeName(ProductType productType)
    {
        return productType switch
        {
            ProductType.RM => "Resort Manager",
            ProductType.RML => "Resort Manager Lite",
            ProductType.Custom => "Custom",
            _ => throw new NotImplementedException(),
        };
    }

    private static string GetLicenseTypeName(LicenseType licenseType)
    {
        return licenseType switch
        {
            LicenseType.Trial => "Trial",
            LicenseType.Full => "Full",
            LicenseType.Error => "Error",
            LicenseType.None => "None",
            _ => throw new NotImplementedException(),
        };
    }

    #endregion Private Helpers
}
