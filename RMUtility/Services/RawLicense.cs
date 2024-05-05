using Standard.Licensing;

namespace RMUtility.Services;

internal class RawLicense
{
    public Guid Serial { get; set; }
    public Models.Customer? Customer { get; set; }
    public DateTime ExpiresDate { get; set; }
    public List<Feature>? Features { get; set; }
    public LicenseType LicenseType { get; set; }
    public LicenseOptions? Options { get; set; }
    public ProductType ProductType { get; set; }
    public string? AllowedVersion { get; set; }
}
