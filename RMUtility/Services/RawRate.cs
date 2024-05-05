namespace RMUtility.Services;

internal class RawRate
{
    public string BaseCurrency { get; set; } = string.Empty;
    public string RateCode { get; set; } = string.Empty;
    public decimal CurrentRate { get; set; }
}
