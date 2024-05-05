namespace RMUtility.Services;

internal interface IRMCloudService
{
    Task<ImmutableList<Rate>> GetRates(string baseCurrency);

    Task<ImmutableList<License>> GetLicenses(string searchText);

    Task<License> CreateNewLicense();

    Task<License> ExtendExpiryDate(License license, DateTime newExpiryDate);

    Task<License> UpdateLicense(License license);
}
