using Standard.Licensing;

namespace RMUtility.Business.Models;

public record NewLicenseRequest(Guid Serial, RMUtility.Models.Customer Customer, DateTime ExpiresDate, ImmutableList<Feature> Features, LicenseType LicenseType, LicenseOptions Options, ProductType ProductType, string AllowedVersion);
