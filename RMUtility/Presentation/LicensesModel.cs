namespace RMUtility.Presentation;

internal partial record LicensesModel(IRMCloudService RMCloudService)
{
    public IState<string> SearchText => State<string>.Value(this, () => "");

    public IListFeed<License> Licenses => SearchText.SelectAsync(async (searchText, ct) => await RMCloudService.GetLicenses(searchText)).AsListFeed();

    public string Title { get; } = "Licenses";

}
