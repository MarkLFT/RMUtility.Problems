namespace RMUtility.Presentation;

public sealed partial class LoginPage : Page
{
    public LoginPage()
    {
        this.DataContext<BindableLoginModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Required)
            .Background(Theme.Brushes.Background.Default)
            .Content(new Grid()
                .SafeArea(SafeArea.InsetMask.All)
                .RowDefinitions("Auto,*")
                .Children(
                    new NavigationBar().Content(() => vm.Title),
                    new StackPanel()
                        .Grid(row: 1)
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Center)
                        .Width(200)
                        .Spacing(16)
                        .Children(
                            new Button()
                                .Content("Login")
                                .HorizontalAlignment(HorizontalAlignment.Stretch)
                                .Command(() => vm.Login)))));
    }
}
