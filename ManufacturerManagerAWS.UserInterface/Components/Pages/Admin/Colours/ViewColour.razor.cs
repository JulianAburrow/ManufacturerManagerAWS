namespace ManufacturerManagerAWS.UserInterface.Components.Pages.Admin.Colours;

public partial class ViewColour
{
    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(ColourId))
        {
            return;
        }

        Colour = await ColourService.GetColourDetailsAsync(ColourId);

        if (Colour is null)
        {
            Snackbar.Add($"{ColourSingular} not found", Severity.Warning);
            NavigationManager.NavigateTo($"/{ColourPlural.ToLower()}/list{ColourPlural.ToLower()}");
            return;
        }

        PreventDeleting = Colour.Widgets.Count > 0;
        MainLayout.SetHeaderValue($"View {ColourSingular}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem($"View {ColourSingular}"),
        ]);
    }
}
