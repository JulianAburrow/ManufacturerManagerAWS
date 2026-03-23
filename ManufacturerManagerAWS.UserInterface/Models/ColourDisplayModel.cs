namespace ManufacturerManagerAWS.UserInterface.Models;

public class ColourDisplayModel
{
    [Required(ErrorMessage = "{0} is required")]
    public string Name { get; set; } = string.Empty;
}
