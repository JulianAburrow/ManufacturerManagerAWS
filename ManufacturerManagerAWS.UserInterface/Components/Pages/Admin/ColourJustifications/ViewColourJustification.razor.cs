namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Admin.ColourJustifications;

public partial class ViewColourJustification
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
            Snackbar.Add($"{ColourJustificationSingular} not found.", Severity.Warning);
            NavigationManager.NavigateTo($"/{ColourJustificationPlural.ToLower()}/list{ColourJustificationPlural.ToLower()}");
            return;
        }

        PreventDeleting = ColourJustification.Widgets.Count > 0;
        MainLayout.SetHeaderValue($"View {ColourJustificationSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"View {ColourJustificationSingular}"),
        ]);
    }
}