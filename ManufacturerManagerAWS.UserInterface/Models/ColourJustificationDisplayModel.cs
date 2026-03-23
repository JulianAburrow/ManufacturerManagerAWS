namespace ManufacturerManagerAWS.UserInterface.Models;

public class ColourJustificationDisplayModel
{
    [Required(ErrorMessage = "[0} is required")]
    public string Justification { get; set; } = string.Empty;
}
