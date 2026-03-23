namespace ManufacturerManagerAWS.Application.Services.Manufacturer;

public interface IManufacturerService
{
    Task<ManufacturerDetailsDto> CreateManufacturerAsync(CreateManufacturerRequest request);

    Task<ManufacturerDetailsDto> UpdateManufacturerAsync(UpdateManufacturerRequest request);

    Task<List<ManufacturerWithWidgetCountDto>> GetManufacturersWithWidgetCountAsync(IEnumerable<ManufacturerModel>? manufacturers = null);

    Task<ManufacturerDetailsDto?> GetManufacturerDetailsAsync(string manufacturerId);

    Task<List<ManufacturerSummaryDto>> GetManufacturerSummariesAsync();
}
