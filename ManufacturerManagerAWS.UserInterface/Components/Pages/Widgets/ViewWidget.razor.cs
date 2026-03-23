namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Widgets;

public partial class ViewWidget
{
    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(WidgetId))
        {
            return;
        }

        Widget = await WidgetService.GetWidgetDetailsAsync(WidgetId);

        if (Widget is null)
        {
            Snackbar.Add($"{WidgetSingular} not found.", Severity.Warning);
            NavigationManager.NavigateTo($"/{WidgetPlural.ToLower()}/list{WidgetPlural.ToLower()}");
            return;
        }

        MainLayout.SetHeaderValue($"View {WidgetSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetWidgetHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"View {WidgetSingular}"),
        ]);
    }
}