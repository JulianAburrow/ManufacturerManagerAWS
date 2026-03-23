namespace ManufacturerManagerAWS.Application.Mapping;

public static class ColourMappingExtensions
{
    public static ColourDetailsDto ToDto(this ColourModel model) => new()
    {
        ColourId = model.ColourId,
        Name = model.Name,
    };

    public static ColourModel ToModel(this CreateColourRequest request) => new()
    {
        ColourId = $"COLOUR#{Guid.NewGuid()}",
        Name = request.Name,
    };

    public static ColourModel ToModel(this UpdateColourRequest request) => new()
    {
        ColourId = request.ColourId,
        Name = request.Name,
    };
}
