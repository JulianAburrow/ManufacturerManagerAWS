using ManufacturerManagerAWS.Application.DTOs.ColourJustifications;

namespace ManufacturerManagerAWS.Application.Mapping;

public static class ColourJustificationMappingExtensions
{
    public static ColourJustificationDetailsDto ToDto(this ColourJustificationModel model) => new()
    {
        ColourJustificationId = model.ColourJustificationId,
        Justification = model.Justification,
    };

    public static ColourJustificationModel ToModel(this CreateColourJustificationRequest request) => new()
    {
        ColourJustificationId = $"COLOURJUSTIFICATION#{Guid.NewGuid()}",
        Justification = request.Justification,
    };

    public static ColourJustificationModel ToModel(this UpdateColourJustificationRequest request) => new()
    {
        ColourJustificationId = request.ColourJustificationId,
        Justification = request.Justification,
    };
}
