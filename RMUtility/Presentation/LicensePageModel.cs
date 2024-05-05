namespace RMUtility.Presentation;

internal partial record LicensePageModel(License License, IRMCloudService RMCloudService)
{

    public string Title { get; } = $"License - {License.Name}";

    public IState<License> LicenseState => State<License>.Value(this, () => License);

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


    public async ValueTask ExtendLicense1Month(CancellationToken ct = default)
    {
        static License? extendExpiresDate(License? license)
        {
            if (license is null) return null;


            license.ExtendLicense(license.ExpiresDate.AddMonths(1));
            return license;
        };

        await LicenseState.UpdateAsync(updater: extendExpiresDate, ct);
    }


    public async ValueTask ExtendLicense1Year(CancellationToken ct = default)
    {
        static License? extendExpiresDate(License? license)
        {
            if (license is null) return null;

            license.ExtendLicense(license.ExpiresDate.AddYears(1));
            return license;
        };

        await LicenseState.UpdateAsync(updater: extendExpiresDate, ct);
    }

}
