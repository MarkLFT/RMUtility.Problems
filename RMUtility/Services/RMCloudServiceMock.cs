namespace RMUtility.Services;
internal class RMCloudServiceMock(ISerializer serializer) : IRMCloudService
{
    #region Rates

    private IEnumerable<RawRate> RateDetails => serializer.FromString<IEnumerable<RawRate>>(RMCloudServiceMockData.RateData)!;

    public Task<ImmutableList<Rate>> GetRates(string baseCurrency)
    {
        var filtered = RateDetails.Where(x => x.BaseCurrency == baseCurrency);

        var rates = filtered.Select(x => new Rate { RateCode = x.RateCode, CurrentRate = x.CurrentRate }).ToImmutableList();

        return Task.FromResult(rates);
    }

    #endregion Rates

    #region Licenses
    private IEnumerable<RawLicense> LicenseDetails { get; set; } = serializer.FromString<IEnumerable<RawLicense>>(RMCloudServiceMockData.LicenseData)!;

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

    //public Task<License> ExtendExpiryDate(License license, DateTime newExpiryDate)
    //{
    //    license.ExtendLicense(newExpiryDate);
    //    return Task.FromResult(license);
    //}

    #endregion Licenses

    #region Email

    public Task<CheckEmailAddressResponse> CheckEmailAddress(string emailAddress)
    {
        var response = new CheckEmailAddressResponse(true, true, false, false, false, false, false, 0.9M);

        return Task.FromResult(response);
    }

    #endregion Email
}
