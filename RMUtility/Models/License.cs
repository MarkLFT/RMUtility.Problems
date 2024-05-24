using Standard.Licensing;
using Customer = RMUtility.Models.Customer;
using LicenseType = Standard.Licensing.LicenseType;

namespace RMUtility.Business.Models;

public partial record License(Guid Serial, Customer Customer, DateTime ExpiresDate, ImmutableList<Feature> Features, LicenseType LicenseType, LicenseOptions Options, ProductType ProductType, string AllowedVersion)
{
    public string Company => Customer?.CustomerName ?? string.Empty;
    public string Name => Customer?.Name ?? string.Empty;
    public string Email => Customer?.EmailAddress ?? string.Empty;
    public string ProductTypeName => GetProductTypeName(ProductType);
    public string LicenseTypeName => GetLicenseTypeName(LicenseType);

    private static readonly int _version = 0;
    public int Version => _version + 1;

    public License ExtendLicense(DateTime newExpiresDate)
    {
        return new License(Serial, Customer, newExpiresDate, Features, LicenseType, Options, ProductType, AllowedVersion);
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
