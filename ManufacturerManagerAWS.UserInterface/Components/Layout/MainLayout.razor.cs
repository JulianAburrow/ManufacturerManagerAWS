namespace ManufacturerManagerAWS.UserInterface.Components.Layout;

public partial class MainLayout
{
    bool _drawerOpen = true;

    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    private readonly List<BreadcrumbItem> Breadcrumbs = [];

    private string HeaderText { get; set; } = null!;

    public void SetHeaderValue(string headerText)
    {
        HeaderText = headerText;
        StateHasChanged();
    }

    public void SetBreadcrumbs(List<BreadcrumbItem> breadcrumbs)
    {
        Breadcrumbs.Clear();
        Breadcrumbs.AddRange(breadcrumbs);
    }
}
