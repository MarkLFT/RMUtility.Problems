namespace RMUtility.Presentation;

internal partial record EmailCheckerModel(IRMCloudService RMCloudService)
{
    public IState<string> EmailAddress => State<string>.Value(this, () => "");

    public IListFeed<Rate> Rates => EmailAddress.SelectAsync(async (baseCurrency, ct) => await RMCloudService.GetRates(baseCurrency)).AsListFeed();

    public string Title { get; } = "Email Address Checker";

}
