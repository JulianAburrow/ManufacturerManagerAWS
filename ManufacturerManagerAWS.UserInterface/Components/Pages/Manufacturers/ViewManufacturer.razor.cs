namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Manufacturers;

public partial class ViewManufacturer
{
    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(ManufacturerId))
        {
            return;
        }

        Manufacturer = await ManufacturerService.GetManufacturerDetailsAsync(ManufacturerId);

        if (Manufacturer is null)
        {
            Snackbar.Add($"{ManufacturerSingular} not found", Severity.Warning);
            NavigationManager.NavigateTo($"/{ManufacturerPlural.ToLower()}/list{ManufacturerPlural.ToLower()}");
            return;
        }

        MainLayout.SetHeaderValue($"View {ManufacturerSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"View {ManufacturerSingular}"),
        ]);
    }
}