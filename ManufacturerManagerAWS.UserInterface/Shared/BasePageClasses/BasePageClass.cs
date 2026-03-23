namespace ManufacturerManagerAWS.UserInterface.Shared.BasePageClasses;

public class BasePageClass : ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;

    [Inject] protected ISnackbar Snackbar { get; set; } = null!;

    [CascadingParameter] public MainLayout MainLayout { get; set; } = null!;

    protected bool PreventDeleting;

    protected BreadcrumbItem GetHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new("Home", "#", isDisabled, icon: Icons.Material.Filled.Home);
    }

    protected BreadcrumbItem GetCustomBreadcrumbItem(string text)
    {
        return new(text, null, true);
    }
}
