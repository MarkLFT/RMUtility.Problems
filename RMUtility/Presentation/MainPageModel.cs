namespace RMUtility.Presentation;

public partial record MainPageModel
{
    //private readonly INavigator _navigator;

    public MainPageModel(
        IOptions<AppConfig> appInfo//,
                                   //IAuthenticationService authentication
                                   //INavigator navigator
        )
    {
        //_navigator = navigator;
        //_authentication = authentication;
        Title = "Main";
        Title += $" - {appInfo?.Value?.Environment}";
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public async ValueTask Logout(CancellationToken token)
    {
        //await _authentication.LogoutAsync(token);
    }

    //private readonly IAuthenticationService _authentication;
}
