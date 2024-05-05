

namespace RMUtility.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.DataContext<BindableMainPageModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Disabled)
            .Background(Theme.Brushes.Background.Default)
            .Content
            (
                new Grid()
                .SafeArea(SafeArea.InsetMask.All)
                .RowDefinitions("Auto,*")
                .Name("NavRoot")
                .Children
                (
                    new NavigationView()
                        .AutomationProperties(automationId: "NavView")
                        .Grid(row: 1)
                        .Name(out var NavView)
                        .PaneDisplayMode(NavigationViewPaneDisplayMode.Auto)
                        .Region(attached: true)
                        .IsSettingsVisible(false)
                        .IsBackButtonVisible(NavigationViewBackButtonVisible.Collapsed)
                        .OpenPaneLength(200)
                        .MenuItems
                        (
                            new NavigationViewItem()
                                .Content("Licenses")
                                .Icon(new SymbolIcon(Symbol.ProtectedDocument))
                                .Region(name: Consts.Routes.Licenses),
                            new NavigationViewItem()
                                .Content("Rates")
                                .Icon(new SymbolIcon(Symbol.Calculator))
                                .Region(name: Consts.Routes.CurrencyRates),
                            new NavigationViewItem()
                                .Content("Email Checker")
                                .Icon(new SymbolIcon(Symbol.Mail))
                                .Region(name: Consts.Routes.EmailChecker)
                        )
                        .Content
                        (
                            new Frame()
                                .Name(out var Frame)
                                .Region(attached: true)
                        )
                    )
                )
            );
    }
}

