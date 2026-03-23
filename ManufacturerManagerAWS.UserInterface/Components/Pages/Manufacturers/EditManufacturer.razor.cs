namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Manufacturers;

public partial class EditManufacturer
{
    private ManufacturerDetailsDto? LoadedManufacturer { get; set; }

    private UpdateManufacturerRequest UpdateManufacturerRequest { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(ManufacturerId))
            return;

        ManufacturerStatuses = await ManufacturerStatusService.GetManufacturerStatusesAsync();

        LoadedManufacturer = await ManufacturerService.GetManufacturerDetailsAsync(ManufacturerId);

        if (LoadedManufacturer is null)
        {
            Snackbar.Add($"{ManufacturerSingular} not found.", Severity.Warning);
            NavigationManager.NavigateTo($"/{ManufacturerPlural.ToLower()}/list{ManufacturerPlural.ToLower()}");
            return;
        }

        ManufacturerDisplayModel.Name = LoadedManufacturer.Name;
        ManufacturerDisplayModel.StatusId = LoadedManufacturer.StatusId;

        MainLayout.SetHeaderValue($"Edit {ManufacturerSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"Edit {ManufacturerSingular}")
        ]);
    }

    private async Task UpdateManufacturerAsync()
    {
        try
        {
            UpdateManufacturerRequest.ManufacturerId = LoadedManufacturer!.ManufacturerId;
            UpdateManufacturerRequest.Name = ManufacturerDisplayModel.Name;
            UpdateManufacturerRequest.StatusId = ManufacturerDisplayModel.StatusId;

            await ManufacturerService.UpdateManufacturerAsync(UpdateManufacturerRequest);

            Snackbar.Add($"{ManufacturerSingular} {UpdateManufacturerRequest.Name} successfully updated.", Severity.Success);
            NavigationManager.NavigateTo($"/{ManufacturerPlural.ToLower()}/list{ManufacturerPlural.ToLower()}");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {ManufacturerSingular.ToLower()} {UpdateManufacturerRequest.Name}. Please try again.", Severity.Error);
        }
    }
}