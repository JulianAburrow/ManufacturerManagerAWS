using System.Drawing;

namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Admin.ColourJustifications;

public partial class DeleteColourJustification
{
    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(ColourJustificationId))
        {
            return;
        }

        ColourJustification = await ColourJustificationService.GetColourJustificationDetailsAsync(ColourJustificationId);

        if (ColourJustification is null)
        {
            Snackbar.Add($"{ColourJustificationSingular} not found", Severity.Warning);
            NavigationManager.NavigateTo($"/{ColourJustificationPlural.ToLower()}/list{ColourJustificationPlural.ToLower()}");
            return;
        }

        PreventDeleting = ColourJustification.Widgets.Count > 0;
        MainLayout.SetHeaderValue($"Delete {ColourJustificationSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"Delete {ColourJustificationSingular}")
        ]);
    }

    private async Task DeleteColourJustificationAsync()
    {
        if (string.IsNullOrWhiteSpace(ColourJustificationId))
            return;

        try
        {
            await ColourJustificationService.DeleteColourJustificationAsync(ColourJustificationId);
            Snackbar.Add($"{ColourJustificationSingular} {ColourJustification!.Justification} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo($"/{ColourJustificationPlural.ToLower()}/list{ColourJustificationPlural.ToLower()}");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {ColourJustificationSingular.ToLower()} {ColourJustification!.Justification}. Please try again.", Severity.Error);
        }
    }
}