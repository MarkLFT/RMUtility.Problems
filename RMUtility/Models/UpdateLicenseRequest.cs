namespace RMUtility.Business.Models;

public class UpdateLicenseRequest
{
    public Guid Serial { get; set; }
    public required License License { get; set; }
}
