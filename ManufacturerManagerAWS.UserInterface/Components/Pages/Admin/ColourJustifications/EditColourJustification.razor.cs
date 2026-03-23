namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Admin.ColourJustifications;

public partial class EditColourJustification
{
    private ColourJustificationDetailsDto? LoadedColourJustification { get; set; }

    private UpdateColourJustificationRequest UpdateColourJustificationRequest { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(ColourJustificationId))
            return;

        LoadedColourJustification = await ColourJustificationService.GetColourJustificationDetailsAsync(ColourJustificationId);

        if (LoadedColourJustification is null)
        {
            Snackbar.Add($"{ColourJustificationSingular} not found.", Severity.Warning);
            NavigationManager.NavigateTo($"/{ColourJustificationPlural.ToLower()}/list{ColourJustificationPlural.ToLower()}");
            return;
        }

        ColourJustificationDisplayModel.Justification = LoadedColourJustification.Justification;

        MainLayout.SetHeaderValue($"Edit {ColourJustificationSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"Edit {ColourJustificationSingular}"),
        ]);
    }

    private async Task UpdateColourJustificationAsync()
    {
        try
        {
            UpdateColourJustificationRequest.ColourJustificationId = LoadedColourJustification!.ColourJustificationId;
            UpdateColourJustificationRequest.Justification = ColourJustificationDisplayModel.Justification;

            await ColourJustificationService.UpdateColourJustificationAsync(UpdateColourJustificationRequest);

            Snackbar.Add($"{ColourJustificationSingular} {UpdateColourJustificationRequest.Justification} successfully updated.", Severity.Success);
            NavigationManager.NavigateTo($"/{ColourJustificationPlural.ToLower()}/list{ColourJustificationPlural.ToLower()}");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {ColourJustificationSingular.ToLower()} {UpdateColourJustificationRequest.Justification}. Please try again.", Severity.Error);
        }
    }
}