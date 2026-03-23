namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Admin.ColourJustifications;

public partial class ListColourJustifciations
{
    protected List<ColourJustificationWithWidgetCountDto> ColourJustificationsWithWidgets { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        ColourJustificationsWithWidgets = await ColourJustificationService.GetColourJustificationsWithWidgetCountAsync();
        Snackbar.Add($"{ColourJustificationsWithWidgets.Count} {(ColourJustificationsWithWidgets.Count == 1 ? ColourJustificationSingular.ToLower() : ColourJustificationPlural.ToLower())} found.", ColourJustificationsWithWidgets.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue($"View {ColourJustificationPlural}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(true),
        ]);
    }
}