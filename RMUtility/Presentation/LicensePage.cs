using System.Runtime.CompilerServices;

namespace RMUtility.Presentation;

public sealed partial class LicensePage : Page
{
    public LicensePage()
    {
        this.DataContext<BindableLicensePageModel>((page, vm) => page
            .Background(Theme.Brushes.Background.Default)
            .Content(
                new ScrollViewer()
                .VerticalScrollBarVisibility(ScrollBarVisibility.Visible)
                .HorizontalScrollBarVisibility(ScrollBarVisibility.Hidden)
                .VerticalScrollMode(ScrollMode.Enabled)
                .HorizontalScrollMode(ScrollMode.Disabled)
                .VerticalAlignment(VerticalAlignment.Stretch)
                .HorizontalAlignment(HorizontalAlignment.Stretch)

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
                                        new Frame()
                                            .Background(Theme.Brushes.Surface.Variant.Default)
                                            .BorderThickness(1)
                                            .BorderBrush(Theme.Brushes.Surface.Variant.Default)
                                            .BorderThickness(2)
                                            .CornerRadius(4)
                                            .Padding(12)
                                            .Content
                                            (
                                                new AutoLayout()
                                                .Spacing(8)
                                                .Children(
                                                    new TextBox()
                                                        .Text(x => x.Binding(() => vm.LicenseState!.Customer!.Name).Mode(BindingMode.TwoWay))
                                                        .Style(Theme.TextBox.Styles.Outlined)
                                                        .PlaceholderText("Company Name")
                                                        .Background(Theme.Brushes.Surface.Default)
                                                        .TextWrapping(TextWrapping.Wrap),
                                                    new TextBox()
                                                        .Text(x => x.Binding(() => vm.LicenseState!.Customer!.CustomerName).Mode(BindingMode.TwoWay))
                                                        .Style(Theme.TextBox.Styles.Outlined)
                                                        .PlaceholderText("Contact Name")
                                                        .Background(Theme.Brushes.Surface.Default)
                                                        .TextWrapping(TextWrapping.Wrap),
                                                    new TextBox()
                                                        .Text(x => x.Binding(() => vm.LicenseState!.Customer!.EmailAddress).Mode(BindingMode.TwoWay))
                                                        .Style(Theme.TextBox.Styles.Outlined)
                                                        .PlaceholderText("Email Address")
                                                        .Background(Theme.Brushes.Surface.Default)
                                                        .TextWrapping(TextWrapping.Wrap)
                                                )
                                            ),
                                        new Frame()
                                            .Background(Theme.Brushes.Surface.Variant.Default)
                                            .BorderThickness(1)
                                            .BorderBrush(Theme.Brushes.Surface.Variant.Default)
                                            .BorderThickness(2)
                                            .CornerRadius(4)
                                            .Margin(0, 12, 0, 0)
                                            .Padding(12)
                                            .Content
                                            (
                                                new AutoLayout()
                                                .Spacing(8)
                                                .Children(
                                                    new TextBox()
                                                        .Text(x => x.Binding(() => vm.LicenseState.Serial).Mode(BindingMode.OneWay))
                                                        .Style(Theme.TextBox.Styles.Outlined)
                                                        .PlaceholderText("Serial No.")
                                                        .Background(Theme.Brushes.Surface.Default)
                                                        .TextWrapping(TextWrapping.Wrap)
                                                        .IsReadOnly(true),
                                                    new StackPanel()
                                                        .Orientation(Orientation.Horizontal)
                                                        .Spacing(8)
                                                        .Children(
                                                            new CalendarDatePicker()
                                                                .Date(x => x.Binding(() => vm.LicenseState.ExpiresDate)
                                                                    .Converter(Converters.Converters.DateTimeOffsetConverter)
                                                                    .Mode(BindingMode.TwoWay))
                                                                //.Style(Theme.CalendarDatePicker.Styles.Default)
                                                                //.BorderThickness(1)
                                                                //.BorderBrush(Theme.Brushes.Primary.Default)
                                                                .Header("Expires Date")
                                                                .Background(Theme.Brushes.Surface.Default)
                                                                .Margin(0, 0, 12, 0),
                                                            new Button()
                                                                .Content("Add 1 Month")
                                                                .Style(Theme.Button.Styles.Outlined)
                                                                .Background(Theme.Brushes.Primary.Default)
                                                                .Foreground(Theme.Brushes.OnPrimary.Default)
                                                                .Command(() => vm.ExtendLicense1Month)
                                                                .Margin(0, 0, 12, 0),
                                                            new Button()
                                                                .Content("Add 1 Year")
                                                                .Style(Theme.Button.Styles.Outlined)
                                                                .Background(Theme.Brushes.Primary.Default)
                                                                .Foreground(Theme.Brushes.OnPrimary.Default)
                                                                .Command(() => vm.ExtendLicense1Year)
                                                         ),
                                                    new ComboBox()
                                                        .SelectedItem(x => x.Binding(() => (int)vm.LicenseState.ProductType)
                                                            .Converter(Converters.Converters.ProductTypeConverter)
                                                            .Mode(BindingMode.TwoWay))
                                                        //.Style(Theme.ComboBox.Styles.Default)
                                                        .PlaceholderText("Product Type")
                                                        .Background(Theme.Brushes.Surface.Default)
                                                        .ItemsSource(x => x.Binding(() => vm.ProductTypes))
                                                        .Height(50),
                                                    new ComboBox()
                                                        .SelectedItem(x => x.Binding(() => (int)vm.LicenseState.LicenseType)
                                                            .Converter(Converters.Converters.LicenseTypeConverter)
                                                            .Mode(BindingMode.TwoWay))
                                                        //.Style(Theme.ComboBox.Styles.Default)
                                                        .PlaceholderText("License Type")
                                                        .Background(Theme.Brushes.Surface.Default)
                                                        .ItemsSource(x => x.Binding(() => vm.LicenseTypes))
                                                        .Height(50),
                                                    new TextBox()
                                                        .Text(x => x.Binding(() => vm.LicenseState.AllowedVersion).Mode(BindingMode.TwoWay))
                                                        .Style(Theme.TextBox.Styles.Outlined)
                                                        .PlaceholderText("Allowed Versions")
                                                        .Background(Theme.Brushes.Surface.Default)
                                                        .TextWrapping(TextWrapping.Wrap)
                                                )
                                            ),
                                        new Frame()
                                            .Background(Theme.Brushes.Surface.Variant.Default)
                                            .BorderThickness(1)
                                            .BorderBrush(Theme.Brushes.Surface.Variant.Default)
                                            .BorderThickness(2)
                                            .CornerRadius(4)
                                            .Margin(0, 12, 0, 0)
                                            .Padding(12)
                                            .Content
                                            (
                                                new AutoLayout()
                                                .Spacing(8)
                                                .Children(
                                                    new Grid()
                                                    .RowDefinitions("Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto,Auto")
                                                    .ColumnDefinitions("Auto,*")
                                                    .Children(
                                                        new TextBlock()
                                                            .Text("Options")
                                                            .Style(Theme.TextBlock.Styles.TitleMedium)
                                                            .VerticalAlignment(VerticalAlignment.Center)
                                                            .Grid(row: 0, column: 0, columnSpan: 2),
                                                        MakeOptions(1, "Activities Module", () => vm.LicenseState.Options!.ACT),
                                                        MakeOptions(2, "CSV Export Module", () => vm.LicenseState.Options!.CSV),
                                                        MakeOptions(3, "Currency Module", () => vm.LicenseState.Options!.CUR),
                                                        MakeOptions(4, "Events Module", () => vm.LicenseState.Options!.EVENTS),
                                                        MakeOptions(5, "Front Desk Mobile", () => vm.LicenseState.Options!.FDM),
                                                        MakeOptions(6, "GDS Module", () => vm.LicenseState.Options!.GDS),
                                                        MakeOptions(7, "Housekeeping Mobile", () => vm.LicenseState.Options!.HK),
                                                        MakeOptions(8, "Internet Module", () => vm.LicenseState.Options!.INet),
                                                        MakeOptions(9, "Locks Module", () => vm.LicenseState.Options!.Locks),
                                                        MakeOptions(10, "PBX Module", () => vm.LicenseState.Options!.PBX),
                                                        MakeOptions(11, "PoS Mobile", () => vm.LicenseState.Options!.PM),
                                                        MakeOptions(12, "Retreats Module", () => vm.LicenseState.Options!.Retreat),
                                                        MakeOptions(13, "Revenue Management (Basic)", () => vm.LicenseState.Options!.RevManBasic),
                                                        MakeOptions(14, "Revenue Management (Full)", () => vm.LicenseState.Options!.RevManFull),
                                                        MakeOptions(15, "Spa Module", () => vm.LicenseState.Options!.SPA)
                                                    )
                                               )
                                          ),
                                        new Frame()
                                            .Background(Theme.Brushes.Surface.Variant.Default)
                                            .BorderThickness(1)
                                            .BorderBrush(Theme.Brushes.Surface.Variant.Default)
                                            .BorderThickness(2)
                                            .CornerRadius(4)
                                            .Margin(0, 12, 0, 0)
                                            .Padding(12)
                                            .Content
                                            (
                                                new AutoLayout()
                                                .Spacing(8)
                                                .Children(
                                                    new Grid()
                                                    .RowDefinitions("Auto,Auto,Auto,Auto,Auto,Auto")
                                                    .ColumnDefinitions("Auto")
                                                    .Children(
                                                        new TextBlock()
                                                            .Text("Features")
                                                            .Style(Theme.TextBlock.Styles.TitleMedium)
                                                            .VerticalAlignment(VerticalAlignment.Center)
                                                            .Grid(row: 0, column: 0, columnSpan: 2),
                                                        MakeFeatures(1, "Revenue Stats", true, () => vm.LicenseState.Features![0].Value),
                                                        MakeFeatures(2, "Samahita Occupancy", true, () => vm.LicenseState.Features![1].Value),
                                                        MakeFeatures(3, "Samahita Revenue", true, () => vm.LicenseState.Features![2].Value),
                                                        MakeFeatures(4, "Code Owners (Discontinued)", false, () => vm.LicenseState.Features![3].Value),
                                                        MakeFeatures(5, "Lanna Owners (Discontinued)", false, () => vm.LicenseState.Features![4].Value)
                                                    )
                                               )
                                          )
                                    )
                              )
                        )
                 )
          );
    }

    private static Grid MakeOptions(int row, string label, Func<bool> property, [CallerArgumentExpression(nameof(property))] string? expression = null)
    {
        return new Grid()
            .ColumnDefinitions("6*,*")
            .RowDefinitions("Auto")
            .Grid(row: row)
            .Children
            (
                 new TextBlock()
                     .Text(label)
                     .VerticalAlignment(VerticalAlignment.Center)
                     .Padding(12, 0, 24, 0),
                 new ToggleSwitch()
                     .Grid(column: 1)
                     .IsOn(x => x.Binding(property, expression)
                        .Mode(BindingMode.TwoWay))
                     .Style(Theme.ToggleSwitch.Styles.Default)
                     .Foreground(Theme.Brushes.OnPrimary.Default)
           );
    }

    private static Grid MakeFeatures(int row, string label, bool isEnabled, Func<string> property, [CallerArgumentExpression(nameof(property))] string? expression = null)
    {
        return new Grid()
            .ColumnDefinitions("6*,*")
            .RowDefinitions("Auto")
            .Grid(row: row)
            .Children
            (
                 new TextBlock()
                     .Text(label)
                     .VerticalAlignment(VerticalAlignment.Center)
                     .Padding(12, 0, 24, 0),
                 new ToggleSwitch()
                     .Grid(column: 1)
                     .IsOn(x => x.Binding(property, expression)
                        .Mode(BindingMode.TwoWay).Converter(Converters.Converters.StringBoolConverter))
                     .Style(Theme.ToggleSwitch.Styles.Default)
                     .Foreground(Theme.Brushes.OnPrimary.Default)
                     .IsEnabled(isEnabled)
           );
    }

}

