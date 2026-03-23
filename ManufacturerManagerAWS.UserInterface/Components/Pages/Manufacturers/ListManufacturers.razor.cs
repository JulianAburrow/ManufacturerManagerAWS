namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Manufacturers;

public partial class ListManufacturers
{
    protected List<ManufacturerWithWidgetCountDto> ManufacturersWithWidgets { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        ManufacturersWithWidgets = await ManufacturerService.GetManufacturersWithWidgetCountAsync();
        Snackbar.Add($"{ManufacturersWithWidgets.Count} {(ManufacturersWithWidgets.Count == 1 ? ManufacturerSingular.ToLower() : ManufacturerPlural.ToLower())} found.", ManufacturersWithWidgets.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue($"View {ManufacturerPlural}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(true),
        ]);
    }
}