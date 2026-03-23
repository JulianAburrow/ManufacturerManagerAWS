namespace ManufacturerManagerAWS.Application.DTOs.ColourJustifications;

public class UpdateColourJustificationRequest
{
    public string ColourJustificationId { get; set; } = default!;

    public string Justification { get; set;} = default!;
}
