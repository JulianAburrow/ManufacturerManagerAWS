namespace ManufacturerManagerAWS.Application.Services.Colour;

public interface IColourService
{
    Task<ColourDetailsDto> CreateColourAsync(CreateColourRequest request);

    Task DeleteColourAsync(string colourId);

    Task<ColourDetailsDto> UpdateColourAsync(UpdateColourRequest request);

    Task<List<ColourWithWidgetCountDto>> GetColoursWithWidgetCountAsync(IEnumerable<ColourModel>? colours = null);

    Task<ColourDetailsDto?> GetColourDetailsAsync(string colourId);

    Task<List<ColourDetailsDto>> GetColourDetailsListAsync();
}
