namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Admin.Colours;

public partial class ListColours
{
    protected List<ColourWithWidgetCountDto> ColoursWithWidgets { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        ColoursWithWidgets = await ColourService.GetColoursWithWidgetCountAsync();
        Snackbar.Add($"{ColoursWithWidgets.Count} {(ColoursWithWidgets.Count == 1 ? ColourSingular.ToLower() : ColourPlural.ToLower())} found.", ColoursWithWidgets.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue($"View {ColourPlural}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourHomeBreadcrumbItem(true)
        ]);
    }
}