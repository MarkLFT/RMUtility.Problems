using System.Runtime.CompilerServices;

namespace RMUtility.Presentation;

public sealed partial class EmailChecker : Page
{
    public EmailChecker()
    {
        this.DataContext<BindableEmailCheckerModel>((page, vm) => page
            .Background(Theme.Brushes.Background.Medium)
            .Content(
                new Grid()
                .RowDefinitions("Auto,*")
                .Children(
                    new NavigationBar()
                        .Content(() => vm.Title),
                    new AutoLayout()
                        .Grid(row: 1)
                        .Background(Theme.Brushes.Surface.Default)
                        .Padding(12)
                        .Children
                        (
                            new TextBox()
                                .Background(Theme.Brushes.Surface.Variant.Default)
                                .Text(b => b
                                     .Binding(() => vm.EmailAddress)
                                        .TwoWay()
                                        .UpdateSourceTrigger(UpdateSourceTrigger.Default))
                                .Height(40)
                                .PlaceholderText("Search...")
                                .CornerRadius(20)
                                .BorderThickness(0)
                                .Padding(12)
                                .Margin(0, 0, 0, 12)
                .AutoLayout
                (
                    counterAlignment: AutoLayoutAlignment.Stretch,
                    primaryAlignment: AutoLayoutPrimaryAlignment.Stretch
                )
                        .ControlExtensions
                        (
                            icon:
                                        new SymbolIcon(Symbol.Find)
                                           .Foreground(Theme.Brushes.Primary.Default)
                        ),
                             new Border()
                                .CornerRadius(12)
                                .Padding(6)
                                .BorderBrush(Theme.Brushes.Surface.Variant.Default)
                                .BorderThickness(2)
                                .Margin(0, 12)
                                .Child
                                (
                                    new Grid()
                                    .RowDefinitions("Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto")
                                    .ColumnDefinitions("Auto,*")
                        .Children
                        (
                            new TextBlock()
                                            .Text("Results")
                                            .Style(Theme.TextBlock.Styles.TitleMedium)
                                            .VerticalAlignment(VerticalAlignment.Center)
                                            .Grid(row: 0, column: 0)
                                            .Margin(0, 0, 0, 12),
                                        DisplayResult(1, "Email Address", () => vm.EmailAddress),
                                        DisplayResult(2, "Catch All", () => vm.CheckResults.CatchAll),
                                        DisplayResult(3, "Format Valid", () => vm.CheckResults.FormatValid),
                                        DisplayResult(4, "Is Disposable", () => vm.CheckResults.IsDisposable),
                                        DisplayResult(5, "Is Free", () => vm.CheckResults.IsFree),
                                        DisplayResult(6, "MX Found", () => vm.CheckResults.MxFound),
                                        DisplayResult(7, "Role", () => vm.CheckResults.Role),
                                        DisplayResult(8, "Score", () => vm.CheckResults.Score),
                                        DisplayResult(9, "SMTP Check", () => vm.CheckResults.SmtpCheck)
                        )
                                )
          ))));
    }

    private static Grid DisplayResult(int row, string label, Func<object> property, [CallerArgumentExpression(nameof(property))] string? expression = null)
    {
        return new Grid()
            .ColumnDefinitions("6*,*")
            .RowDefinitions("Auto")
            .Grid(row: row)
                    .Children
                    (
                        new TextBlock()
                     .Text(string.IsNullOrEmpty(label) ? "-" : label)
                     .VerticalAlignment(VerticalAlignment.Center)
                     .Style(Theme.TextBlock.Styles.TitleMedium)
                     .Padding(12, 0, 24, 0),
                        new TextBlock()
                     .Grid(column: 1)
                     .Text(x => x.Binding(property, expression))
                     .Style(Theme.TextBlock.Styles.TitleMedium)
                     .Foreground(Theme.Brushes.Primary.Default)
                     .Padding(12, 0, 12, 0)
                    );
    }
}

