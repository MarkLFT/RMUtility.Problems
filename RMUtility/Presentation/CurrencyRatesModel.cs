
namespace RMUtility.Presentation;

internal partial record CurrencyRatesModel(IRMCloudService RMCloudService)
{
    public IState<string> BaseCurrency => State<string>.Value(this, () => "USD");

    public IListFeed<Rate> Rates => BaseCurrency.SelectAsync(async (baseCurrency, ct) => await RMCloudService.GetRates(baseCurrency)).AsListFeed();

    public string Title { get; } = "Currency Rates";

}
