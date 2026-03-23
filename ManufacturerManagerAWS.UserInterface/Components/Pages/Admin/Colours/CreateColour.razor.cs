namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Admin.Colours;

public partial class CreateColour
{
    private CreateColourRequest CreateColourRequest { get; set; } = new();

    protected override async Task OnInitializedAsync() =>
        MainLayout.SetHeaderValue($"Create {ColourSingular}");

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"Create {ColourSingular}")
        ]);
    }

    private async Task CreateColourAsync()
    {
        try
        {
            CreateColourRequest.Name = ColourDisplayModel.Name;

            await ColourService.CreateColourAsync(CreateColourRequest);

            Snackbar.Add($"Colour {CreateColourRequest.Name} successfully created.", Severity.Success);
            NavigationManager.NavigateTo($"/{ColourPlural.ToLower()}/list{ColourPlural.ToLower()}");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {ColourSingular} {CreateColourRequest.Name}. Please try again.", Severity.Error);
        }
    }
}