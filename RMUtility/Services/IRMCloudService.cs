namespace RMUtility.Services;

internal interface IRMCloudService
{
    #region Rates

    Task<ImmutableList<Rate>> GetRates(string baseCurrency);

    #endregion Rates

    #region Licenses
    Task<ImmutableList<License>> GetLicenses(string searchText);

    Task<License> CreateNewLicense();

    //Task<License> ExtendExpiryDate(License license, DateTime newExpiryDate);

    Task<License> UpdateLicense(License license);

    #endregion Licenses

    #region Email

    Task<CheckEmailAddressResponse> CheckEmailAddress(string emailAddress);

    #endregion Email
}
