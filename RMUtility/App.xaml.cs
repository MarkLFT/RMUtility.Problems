using System.Text.Json;
using Uno.Resizetizer;

namespace RMUtility;
public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();
    }

    protected Window? MainWindow { get; private set; }
    protected IHost? Host { get; private set; }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        // Load WinUI Resources
        Resources.Build(r => r.Merged(
            new XamlControlsResources()));

        // Load Uno.UI.Toolkit and Material Resources
        Resources.Build(r => r.Merged(
            new MaterialToolkitTheme(
                    new Styles.ColorPaletteOverride(),
                    new Styles.MaterialFontsOverride())));

        var builder = this.CreateBuilder(args)
            // Add navigation support for toolkit controls such as TabBar and NavigationView
            .UseToolkitNavigation()
            .Configure(host => host
#if DEBUG
                // Switch to Development environment when running in DEBUG
                .UseEnvironment(Environments.Development)
#endif
                .UseLogging(configure: (context, logBuilder) =>
                {
                    // Configure log levels for different categories of logging
                    logBuilder
                        .SetMinimumLevel(
                            context.HostingEnvironment.IsDevelopment() ?
                                LogLevel.Information :
                                LogLevel.Warning)

                        // Default filters for core Uno Platform namespaces
                        .CoreLogLevel(LogLevel.Warning);

                    // Uno Platform namespace filter groups
                    // Uncomment individual methods to see more detailed logging
                    //// Generic Xaml events
                    //logBuilder.XamlLogLevel(LogLevel.Debug);
                    //// Layout specific messages
                    //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
                    //// Storage messages
                    //logBuilder.StorageLogLevel(LogLevel.Debug);
                    //// Binding related messages
                    //logBuilder.XamlBindingLogLevel(LogLevel.Debug);
                    //// Binder memory references tracking
                    //logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
                    //// DevServer and HotReload related
                    //logBuilder.HotReloadCoreLogLevel(LogLevel.Information);
                    //// Debug JS interop
                    //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);

                }, enableUnoLogging: true)
                .UseSerilog(consoleLoggingEnabled: true, fileLoggingEnabled: true)
                .UseConfiguration(configure: configBuilder =>
                    configBuilder
                        .EmbeddedSource<App>()
                        .Section<AppConfig>()
                )
                // Register Json serializers (ISerializer and ISerializer)
                .UseSerialization(services =>
                {
                    //services.AddJsonTypeInfo(RateContext.Default.Rate);
                    services.AddJsonTypeInfo(RawRateContext.Default.RawRate);
                    services.AddJsonTypeInfo(LicenseContext.Default.RawLicense);
                    services.AddSingleton(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                })
                .UseHttp((context, services) =>
                {
                    // Register HttpClient
#if DEBUG
                    // DelegatingHandler will be automatically injected into Refit Client
                    services.AddTransient<DelegatingHandler, DebugHttpHandler>();
#endif
                    services.AddRefitClient<IRMCloud>(context);
                })
                //.UseAuthentication(auth =>
                //    auth.AddOidc()
                //)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IRMCloudService, RMCloudServiceMock>();
                })
                .UseNavigation(ReactiveViewModelMappings.ViewModelMappings, RegisterRoutes)
            );
        MainWindow = builder.Window;

#if DEBUG
        MainWindow.EnableHotReload();
#endif
        MainWindow.SetWindowIcon();

        Host = await builder.NavigateAsync<Shell>
            (initialNavigate: async (services, navigator) =>
            {
                //var auth = services.GetRequiredService<IAuthenticationService>();
                //var authenticated = await auth.RefreshAsync();
                //if (authenticated)
                //{
                await navigator.NavigateViewModelAsync<MainPageModel>(this, qualifier: Qualifiers.Nested);
                //}
                //else
                //{
                //    await navigator.NavigateViewModelAsync<LoginModel>(this, qualifier: Qualifiers.Nested);
                //}
            });
    }

    private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        views.Register(
            new ViewMap(ViewModel: typeof(ShellModel)),
            new ViewMap<LoginPage, LoginModel>(),
            new ViewMap<MainPage, MainPageModel>(),
            new ViewMap<CurrencyRates, CurrencyRatesModel>(),
            new ViewMap<Licenses, LicensesModel>(),
            new ViewMap<EmailChecker, EmailCheckerModel>(),
            new DataViewMap<LicensePage, LicensePageModel, License>()
        );

        routes.Register(
            new RouteMap("", View: views.FindByViewModel<ShellModel>(),
                Nested:
                [
                    new RouteMap(Consts.Routes.Login, View: views.FindByViewModel<LoginModel>()),
                    new RouteMap(Consts.Routes.MainPage, View: views.FindByViewModel<MainPageModel>()),
                    //Nested:
                    //[
                        new RouteMap(Consts.Routes.CurrencyRates, View: views.FindByViewModel<CurrencyRatesModel>()),
                        new RouteMap(Consts.Routes.Licenses, View: views.FindByViewModel<LicensesModel>()),
                        new RouteMap(Consts.Routes.License, View: views.FindByViewModel<LicensePageModel>()),
                        new RouteMap(Consts.Routes.EmailChecker, View: views.FindByViewModel<EmailCheckerModel>())
                    //]
                    //)
                ]
            )
        );
    }
}
