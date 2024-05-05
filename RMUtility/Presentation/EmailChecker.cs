using Path = Microsoft.UI.Xaml.Shapes.Path;

namespace RMUtility.Presentation;

public sealed partial class EmailChecker : Page
{
    public EmailChecker()
    {
        this.DataContext<BindableEmailCheckerModel>((page, vm) => page
            .Background(Theme.Brushes.Background.Default)
            .Content(
                new AutoLayout()
                .PrimaryAxisAlignment(AutoLayoutAlignment.Start)
                .CounterAxisAlignment(AutoLayoutAlignment.Center)
                .VerticalAlignment(VerticalAlignment.Stretch)
                .Width(400)
                .Children(
                    new NavigationBar()
                        .Content(() => vm.Title),
                    new AutoLayout()
                        .Background(Theme.Brushes.Surface.Default)
                        .CounterAxisAlignment(AutoLayoutAlignment.Start)
                        .Padding(12)
                        .AutoLayout(counterAlignment: AutoLayoutAlignment.Stretch)
                        .Children
                        (
                            new TextBox()
                                .Background(Theme.Brushes.Surface.Variant.Default)
                                .Text(b => b
                                     .Binding(() => vm.EmailAddress)
                                        .TwoWay()
                                        .UpdateSourceTrigger(UpdateSourceTrigger.PropertyChanged))
                                .Height(40)
                                .PlaceholderText("Base Currency")
                                .MaxLength(3)
                                .CornerRadius(20)
                                .BorderThickness(0)
                                .AutoLayout(counterAlignment: AutoLayoutAlignment.Stretch)
                                .ControlExtensions
                                (
                                    icon:
                                        new PathIcon()
                                            .Data(StaticResource.Get<Geometry>("Icon_Search"))
                                            .Foreground(Theme.Brushes.OnSurface.Variant.Default)
                                ),
                           new FeedView()
                                    .AutoLayout(primaryAlignment: AutoLayoutPrimaryAlignment.Stretch)
                                    .VerticalAlignment(VerticalAlignment.Stretch)
                                    .VerticalContentAlignment(VerticalAlignment.Stretch)
                                    .Source(() => vm.Rates)
                                    .Background(Theme.Brushes.Primary.Default)
                                    .NoneTemplate(RateNoneTemplate)
                                    .ErrorTemplate(RateErrorTemplate)
                                    .ValueTemplate<FeedViewState>(feedViewState =>
                                            new ListView()
                                                    .Background(Theme.Brushes.Secondary.Default)
                                                    .ItemsSource(() => feedViewState.Data)
                                                    .Padding(12, 8)
                                                   //.Navigation(request: "VideoDetails")
                                                   //.IsItemClickEnabled(true)
                                                   .AutoLayout
                                                   (
                                                        primaryAlignment: AutoLayoutPrimaryAlignment.Stretch,
                                                        counterAlignment: AutoLayoutAlignment.Stretch
                                                   )
                                                   .ItemTemplate<Rate>(RateItemTemplate)
                                        )


                            )
                      )
                )
          );
    }

    private static UIElement RateErrorTemplate() =>
        new AutoLayout()
                .Spacing(8)
                .PrimaryAxisAlignment(AutoLayoutAlignment.Center)
                .CounterAxisAlignment(AutoLayoutAlignment.Center)
                .AutoLayout
                (
                    counterAlignment: AutoLayoutAlignment.Stretch,
                    primaryAlignment: AutoLayoutPrimaryAlignment.Stretch
                )
                .Children
                (
                    new AutoLayout()
                        .Spacing(24)
                        .PrimaryAxisAlignment(AutoLayoutAlignment.Center)
                        .CounterAxisAlignment(AutoLayoutAlignment.Center)
                        .Padding(0, 0, 0, 36)
                        .AutoLayout(primaryAlignment: AutoLayoutPrimaryAlignment.Stretch)
                        .Children
                        (
                            new AutoLayout()
                                .PrimaryAxisAlignment(AutoLayoutAlignment.Center)
                                .CounterAxisAlignment(AutoLayoutAlignment.Center)
                                .Width(160)
                                .Height(160)
                                .Children
                                (
                                    new Ellipse()
                                        .Fill(Theme.Brushes.Surface.Default)
                                        .Width(160)
                                        .Height(160),
                                    new Path()
                                        .Data("F1 M 78.19999694824219 1.8000001907348633 C 77.19999694824219 0.6000001430511475 75.60000002384186 0 74 0 L 6 0 C 4.399999976158142 0 2.8000001907348633 0.6000001430511475 1.8000001907348633 1.8000001907348633 C 0.6000001430511475 2.8000001907348633 0 4.399999976158142 0 6 L 0 58 C 0 59.60000002384186 0.6000001430511475 61.19999694824219 1.8000001907348633 62.19999694824219 C 2.8000001907348633 63.3999969959259 4.399999976158142 64 6 64 L 74 64 C 77.20000004768372 64 80 61.200000047683716 80 58 L 80 6 C 80 4.399999976158142 79.3999969959259 2.8000001907348633 78.19999694824219 1.8000001907348633 Z M 74 58 L 6 58 L 6 6 L 74 6 L 74 58 Z M 30.799999237060547 45.400001525878906 L 40 36.20000076293945 L 49.20000076293945 45.400001525878906 L 53.400001525878906 41.20000076293945 L 44.20000076293945 32 L 53.400001525878906 22.799999237060547 L 49.20000076293945 18.600000381469727 L 40 27.799999237060547 L 30.799999237060547 18.600000381469727 L 26.600000381469727 22.799999237060547 L 35.79999923706055 32 L 26.600000381469727 41.20000076293945 L 30.799999237060547 45.400001525878906 Z")
                                        .Fill(Theme.Brushes.Secondary.Default)
                                        .Margin(40, 48)
                                        .VerticalAlignment(VerticalAlignment.Center)
                                        .HorizontalAlignment(HorizontalAlignment.Center)
                                        .Width(80)
                                        .Height(64)
                                        .AutoLayout(isIndependentLayout: true)
                                ),
                            new AutoLayout()
                                .PrimaryAxisAlignment(AutoLayoutAlignment.Center)
                                .CounterAxisAlignment(AutoLayoutAlignment.Center)
                                .Children
                                (
                                    new TextBlock()
                                        .Text("Oh no!")
                                        .Foreground(Theme.Brushes.OnSurface.Default)
                                        .Style(Theme.TextBlock.Styles.HeadlineSmall),
                                    new TextBlock()
                                        .Text("Something went wrong")
                                        .Foreground(Theme.Brushes.OnSurface.Medium)
                                        .Style(Theme.TextBlock.Styles.BodyLarge)
                                )
                        ),
                    new Button()
                        .Content("Retry")
                        .Margin(16, 24)
                        .Style(Theme.Button.Styles.FilledTonal)
                        .AutoLayout(counterAlignment: AutoLayoutAlignment.Stretch)
                        .ControlExtensions
                        (
                            icon:
                                new PathIcon()
                                    .Data(StaticResource.Get<Geometry>("Icon_Refresh"))
                        )
                );

    private static UIElement RateNoneTemplate() =>
        new AutoLayout()
                .Spacing(24)
                .PrimaryAxisAlignment(AutoLayoutAlignment.Center)
                .CounterAxisAlignment(AutoLayoutAlignment.Center)
                .Padding(0, 0, 0, 122)
                .AutoLayout
                (
                    counterAlignment: AutoLayoutAlignment.Center,
                    primaryAlignment: AutoLayoutPrimaryAlignment.Stretch
                )
                .Children
                (
                    new AutoLayout()
                        .PrimaryAxisAlignment(AutoLayoutAlignment.Center)
                        .CounterAxisAlignment(AutoLayoutAlignment.Center)
                        .Width(160)
                        .Height(160)
                        .Children
                        (
                            new Ellipse()
                                .Fill(Theme.Brushes.Surface.Default)
                                .Width(160)
                                .Height(160),
                            new Path()
                                .Data("F1 M 36.57652282714844 15.768688201904297 L 28.12342071533203 24.199007034301758 L 19.670324325561523 15.768688201904297 L 15.811301231384277 19.6173095703125 L 24.264400482177734 28.047626495361328 L 15.811301231384277 36.47794723510742 L 19.670324325561523 40.326568603515625 L 28.12342071533203 31.896251678466797 L 36.57652282714844 40.326568603515625 L 40.435546875 36.47794723510742 L 31.982446670532227 28.047626495361328 L 40.435546875 19.6173095703125 L 36.57652282714844 15.768688201904297 Z M 49.807456970214844 45.64133071899414 C 54.034006118774414 40.693100929260254 56.239158630371094 34.46199989318848 56.239158630371094 27.864360809326172 C 56.239158630371094 20.533650398254395 53.29895353317261 13.38620662689209 47.969825744628906 8.254709243774414 C 42.824461460113525 2.939943790435791 35.65770435333252 -0.17560786567628384 28.12342071533203 0.0076598916202783585 C 20.589137077331543 0.0076598916202783585 13.422379970550537 2.939943790435791 8.277015686035156 8.254709243774414 C 2.947887897491455 13.38620662689209 -0.17608242109417915 20.53364849090576 0.007680591195821762 28.047626495361328 C 0.007680591195821762 35.561604499816895 2.947887897491455 42.7090482711792 8.277015686035156 47.840545654296875 C 13.422379970550537 53.1553111076355 20.589137077331543 56.27085702121258 28.12342071533203 56.087589263916016 C 34.55512619018555 56.087589263916016 40.986831188201904 53.88838005065918 45.94843292236328 49.673221588134766 L 64.32473754882812 68 L 68 63.96811294555664 L 49.807456970214844 45.64133071899414 Z M 44.110801696777344 43.991920471191406 C 39.88425254821777 48.39034700393677 34.18760013580322 50.772829219698906 28.12342071533203 50.589561462402344 C 22.05924129486084 50.772829219698906 16.36258888244629 48.20707893371582 12.136039733886719 43.991920471191406 C 7.725727081298828 39.77676200866699 5.33680821955204 34.09546232223511 5.520571231842041 28.047626495361328 C 5.33680821955204 21.99979066848755 7.909490585327148 16.318490982055664 12.136039733886719 12.10333251953125 C 16.36258888244629 7.704905986785889 22.05924129486084 5.322425201535225 28.12342071533203 5.505692958831787 C 34.18760013580322 5.505692958831787 39.88425254821777 7.888174057006836 44.110801696777344 12.10333251953125 C 48.521114349365234 16.318490982055664 50.91003559529781 21.99979066848755 50.72627258300781 28.047626495361328 C 50.72627258300781 34.09546232223511 48.337350845336914 39.77676200866699 44.110801696777344 43.991920471191406 Z")
                                .Fill(Theme.Brushes.Secondary.Default)
                                .Margin(46, 46, 0, 0)
                                .VerticalAlignment(VerticalAlignment.Top)
                                .HorizontalAlignment(HorizontalAlignment.Left)
                                .Width(68)
                                .Height(68)
                                .AutoLayout(isIndependentLayout: true)
                        ),
                    new AutoLayout()
                        .PrimaryAxisAlignment(AutoLayoutAlignment.Center)
                        .CounterAxisAlignment(AutoLayoutAlignment.Center)
                        .Children
                        (
                            new TextBlock()
                                .Text("No results found")
                                .Foreground(Theme.Brushes.OnSurface.Default)
                                .Style(Theme.TextBlock.Styles.HeadlineSmall),
                            new TextBlock()
                                .Text("Try a new base currency")
                                .Foreground(Theme.Brushes.OnSurface.Medium)
                                .Style(Theme.TextBlock.Styles.BodyLarge)
                        )
                );

    private static UIElement RateItemTemplate(Rate rate) =>
                //new CardContentControl()
                //    .Margin(0, 0, 0, 8)
                //    .HorizontalAlignment(HorizontalAlignment.Stretch)
                //    .Style(StaticResource.Get<Style>("ElevatedCardContentControlStyle"))
                //    .Content
                //    (
                new AutoLayout()
                    .Background(Theme.Brushes.Tertiary.Medium)
                    .CornerRadius(12)
                    .PrimaryAxisAlignment(AutoLayoutAlignment.Stretch)
                    .CounterAxisAlignment(AutoLayoutAlignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Left)
                    .Orientation(Orientation.Horizontal)
                    .Padding(12)
                    .Children
                    (
                        new TextBlock()
                            .Text(() => rate.RateCode)
                            .Height(16)
                            .Foreground(Theme.Brushes.OnSurface.Default)
                            //.Background(Theme.Brushes.Primary.Default)
                            //.Width(100)

                            .Style(Theme.TextBlock.Styles.LabelMedium),
                        new TextBlock()
                            .Text(() => rate.CurrentRate!)
                            .Height(16)
                            //.Width(100)
                            .Foreground(Theme.Brushes.OnSurface.Medium)
                            .Style(Theme.TextBlock.Styles.BodyMedium)
                            .TextAlignment(Microsoft.UI.Xaml.TextAlignment.End)
                    );
}

