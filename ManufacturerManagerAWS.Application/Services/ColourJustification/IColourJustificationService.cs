using ManufacturerManagerAWS.Application.DTOs.ColourJustifications;

namespace ManufacturerManagerAWS.Application.Services.ColourJustification;

public interface IColourJustificationService
{
    Task<ColourJustificationDetailsDto> CreateColourJustificationAsync(CreateColourJustificationRequest request);

    Task DeleteColourJustificationAsync(string colourJustificationId);

    Task<ColourJustificationDetailsDto> UpdateColourJustificationAsync(UpdateColourJustificationRequest request);

    Task<List<ColourJustificationWithWidgetCountDto>> GetColourJustificationsWithWidgetCountAsync(IEnumerable<ColourJustificationModel>? colourJustifications = null);

    Task<ColourJustificationDetailsDto?> GetColourJustificationDetailsAsync(string colourJustificationId);

    Task<List<ColourJustificationDetailsDto>> GetColourJustificationDetailsListAsync();
}
