namespace RMUtility.Presentation;

public partial record LoginModel(IDispatcher Dispatcher, INavigator Navigator, IAuthenticationService Authentication)
{
    public string Title { get; } = "Login";


    public async ValueTask Login(CancellationToken token)
    {
        var success = await Authentication.LoginAsync(Dispatcher, cancellationToken: token);

        if (success)
        {
            await Navigator.NavigateViewModelAsync<MainPageModel>(this, qualifier: Qualifiers.ClearBackStack, cancellation: token);
        }
    }

}
