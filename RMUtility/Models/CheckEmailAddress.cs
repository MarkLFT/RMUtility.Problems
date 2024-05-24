namespace RMUtility.Models;
public class CheckEmailAddress
{
    public required string EmailAddress { get; set; }
    public bool IncludeSmtpCheck { get; set; } = false;
}
