namespace RMUtility.Models;
public class CheckEmailAddressResponse(bool formatValid, bool mxFound, bool smtpCheck, bool catchAll, bool role, bool isDisposable, bool isFree, decimal score)
{
    public static CheckEmailAddressResponse Empty => new(false, false, false, false, false, false, false, 0);

    public bool FormatValid { get; } = formatValid;
    public bool MxFound { get; } = mxFound;
    public bool SmtpCheck { get; } = smtpCheck;
    public bool CatchAll { get; } = catchAll;
    public bool Role { get; } = role;
    public bool IsDisposable { get; } = isDisposable;
    public bool IsFree { get; } = isFree;
    public decimal Score { get; } = score;
}

