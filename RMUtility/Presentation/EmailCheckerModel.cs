namespace RMUtility.Presentation;

internal partial record EmailCheckerModel(IRMCloudService RMCloudService)
{
    public IState<string> EmailAddress => State<string>.Value(this, () => "");

    public IFeed<CheckEmailAddressResponse> CheckResults => EmailAddress.SelectAsync(async (emailAddress, ct) => await RMCloudService.CheckEmailAddress(emailAddress));

    public string Title { get; } = "Email Address Checker";

}
