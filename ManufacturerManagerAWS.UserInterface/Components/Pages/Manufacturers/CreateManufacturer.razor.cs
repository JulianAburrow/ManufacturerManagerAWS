namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Manufacturers;

public partial class CreateManufacturer
{
    private CreateManufacturerRequest CreateManufacturerRequest { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        ManufacturerStatuses = await ManufacturerStatusService.GetManufacturerStatusesAsync();
        ManufacturerStatuses.Insert(0, new ManufacturerStatusDto
        {
            ManufacturerStatusId = SharedValues.PleaseSelectValue,
            Name = SharedValues.PleaseSelectText,
        });
        ManufacturerDisplayModel.StatusId = SharedValues.PleaseSelectValue;

        MainLayout.SetHeaderValue($"Create {ManufacturerSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"Create {ManufacturerSingular}"),
        ]);
    }

    private async Task CreateManufacturerAsync()
    {
        try
        {
            CreateManufacturerRequest.Name = ManufacturerDisplayModel.Name;
            CreateManufacturerRequest.StatusId = ManufacturerDisplayModel.StatusId;

            await ManufacturerService.CreateManufacturerAsync(CreateManufacturerRequest);

            Snackbar.Add($"{ManufacturerSingular} {CreateManufacturerRequest.Name} successfully created", Severity.Success);
            NavigationManager.NavigateTo($"/{ManufacturerPlural.ToLower()}/list{ManufacturerPlural.ToLower()}");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {ManufacturerSingular.ToLower()}. Please try again.", Severity.Error);
        }
    }
}