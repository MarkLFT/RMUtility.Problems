namespace RMUtility.Business.Models;

internal class Rate
{
    public Rate() { }

    public Rate(decimal currentRate, string rateCode)
    {
        CurrentRate = currentRate;
        RateCode = rateCode;
    }

    public decimal CurrentRate { get; set; } = 0M;

    public string RateCode { get; set; } = string.Empty;

    public string DisplayRate => CurrentRate.ToString("#.0000");
}


