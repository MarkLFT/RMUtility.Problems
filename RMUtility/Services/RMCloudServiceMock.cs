namespace RMUtility.Services;
internal class RMCloudServiceMock(ISerializer serializer) : IRMCloudService
{
    private IEnumerable<RawRate> RateDetails => serializer.FromString<IEnumerable<RawRate>>(RMCloudServiceMockData.RateData)!;

    private IEnumerable<RawLicense> LicenseDetails => serializer.FromString<IEnumerable<RawLicense>>(RMCloudServiceMockData.LicenseData)!;

    public Task<ImmutableList<Rate>> GetRates(string baseCurrency)
    {
        var filtered = RateDetails.Where(x => x.BaseCurrency == baseCurrency);

        var rates = filtered.Select(x => new Rate { RateCode = x.RateCode, CurrentRate = x.CurrentRate }).ToImmutableList();

        return Task.FromResult(rates);
    }

    public Task<ImmutableList<License>> GetLicenses(string searchText)
    {
        var filtered = LicenseDetails.Where(x => x.Customer!.Name!.Contains(searchText) || x.Customer!.CustomerName!.Contains(searchText));

        var licenses = filtered.Select(x => new License
        (
            x.Serial,
            x.Customer ?? new Customer(),
            x.ExpiresDate,
            x.Features ?? [],
            x.LicenseType,
            x.Options ?? new LicenseOptions(),
            x.ProductType,
            x.AllowedVersion ?? "9.9.9000"
        )).ToImmutableList();

        return Task.FromResult(licenses);
    }

    public Task<License> CreateNewLicense()
    {
        var license = License.NewLicense();
        return Task.FromResult(license);
    }

    public Task<License> UpdateLicense(License license)
    {
        throw new NotImplementedException();
    }

    public Task<License> ExtendExpiryDate(License license, DateTime newExpiryDate)
    {
        license.ExtendLicense(newExpiryDate);
        return Task.FromResult(license);
    }
}
