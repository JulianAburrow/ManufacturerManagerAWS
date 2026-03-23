namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Admin.ColourJustifications;

public partial class CreateColourJustification
{
    private CreateColourJustificationRequest CreateColourJustificationRequest { get; set; } = new();

    protected override async Task OnInitializedAsync() =>
        MainLayout.SetHeaderValue($"Create {ColourJustificationSingular}");

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"Create {ColourJustificationSingular}"),
        ]);
    }

    private async Task CreateColourJustificationAsync()
    {
        try
        {
            CreateColourJustificationRequest.Justification = ColourJustificationDisplayModel.Justification;

            await ColourJustificationService.CreateColourJustificationAsync(CreateColourJustificationRequest);

            Snackbar.Add($"Colour {CreateColourJustificationRequest.Justification} successfully created.", Severity.Success);
            NavigationManager.NavigateTo($"/{ColourJustificationPlural.ToLower()}/list{ColourJustificationPlural.ToLower()}");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {ColourJustificationSingular} {CreateColourJustificationRequest.Justification}. Please try again.", Severity.Error);
        }
    }
}