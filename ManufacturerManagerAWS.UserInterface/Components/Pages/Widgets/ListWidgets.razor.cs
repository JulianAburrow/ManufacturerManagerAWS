namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Widgets;

public partial class ListWidgets
{
    protected List<WidgetDetailsDto> Widgets { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Widgets = await WidgetService.GetWidgetsAsync();
        Snackbar.Add($"{Widgets.Count} {(Widgets.Count == 1 ? WidgetSingular.ToLower() : WidgetPlural.ToLower())} found.", Widgets.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue($"View {WidgetPlural}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetWidgetHomeBreadcrumbItem(true),
        ]);
    }
}