namespace RMUtility.Business.Models;

public class GetRates
{
    #region Public Properties

    public string BaseCurrency { get; set; } = string.Empty;
    public List<string> RequiredCurrencies { get; set; } = [];

    #endregion Public Properties
}
