namespace RMUtility.Presentation;

internal partial record LicensePageModel(License License, IRMCloudService RMCloudService)
{
    public string Title { get; } = $"License - {License.Name}";

    //public IState<License> LicenseState => State.Value(this, () => new License(Guid.NewGuid(), new Customer { CustomerName = "Mark", EmailAddress = "mark@lftmail.com", Name = "LFT" }, DateTime.Now, null, Standard.Licensing.LicenseType.Full, null, Standard.Licensing.ProductType.RML, "1.0.0")); // new License(License.Serial, License.Customer, License.ExpiresDate, License.Features, License.LicenseType, License.Options, License.ProductType, License.AllowedVersion));

    public IState<License> LicenseState => State.Value(this, () => License); // new License(License.Serial, License.Customer, License.ExpiresDate, License.Features, License.LicenseType, License.Options, License.ProductType, License.AllowedVersion));

    public IEnumerable<string> ProductTypes { get; } =
        [
            Consts.Products.ResortManager,
            Consts.Products.ResortManagerLite,
            Consts.Products.ResortManagerCustom
        ];

    public IEnumerable<string> LicenseTypes { get; } =
        [
            Consts.LicenseTypes.None,
            Consts.LicenseTypes.Trial,
            Consts.LicenseTypes.Full,
            Consts.LicenseTypes.Error
        ];


    public ValueTask ExtendLicense1Month(CancellationToken ct)
    {
        static License? extendExpiresDate(License? license)
        {
            if (license is null) return null;

            return license with { ExpiresDate = license.ExpiresDate.AddMonths(1) };
        };

        return LicenseState.UpdateAsync(updater: extendExpiresDate, ct);

    }


    public ValueTask ExtendLicense1Year(CancellationToken ct = default)
    {
        static License? extendExpiresDate(License? license)
        {
            if (license is null) return null;

            return license.ExtendLicense(license.ExpiresDate.AddYears(1));
        }

        return LicenseState.UpdateAsync(updater: extendExpiresDate, ct);

    }

}
