using Refit;

namespace RMUtility.Services.Endpoints;

[Headers(["Content-Type: application/json", "Authorization: Bearer"])]
internal interface IRMCloud
{

    #region License Endpoints

    [Post("/newlicense")]
    Task<ApiResponse<LicenseResponse>> NewLicense([Body] NewLicenseRequest request);

    [Delete("/deletelicense/{serial}")]
    Task<ApiResponse<bool>> DeleteLicense(string serial);

    [Get("/getlicense/{serial}")]
    Task<ApiResponse<LicenseResponse>> GetLicense(string serial);

    [Get("/getlicenses")]
    Task<ApiResponse<GetLicensesResponse>> GetLicenses();

    [Put("/updatelicense")]
    Task<ApiResponse<UpdateLicenseResponse>> UpdateLicense([Body] UpdateLicenseRequest request);

    #endregion License Endpoints

    #region Rates Endpoints

    [Post("/getrates")]
    Task<ApiResponse<GetRatesResponse>> GetRates([Body] GetRates request);

    #endregion Rates Endpoints

    #region Email Endpoints

    [Post("/checkemailaddress")]
    Task<ApiResponse<CheckEmailAddressResponse>> CheckEmailAddress([Body] CheckEmailAddress request);

    #endregion
}
