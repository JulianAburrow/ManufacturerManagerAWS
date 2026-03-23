namespace ManufacturerManagerAWS.UserInterface.Models;

public class ManufacturerDisplayModel
{
    [Required(ErrorMessage = "{0} is required")]
    public string Name { get; set; } = string.Empty;

    [NotPleaseSelectOrEmpty]
    [Display(Name = "Status")]
    public string StatusId { get; set; } = string.Empty;

    public string StatusName { get; set; } = string.Empty;
}
