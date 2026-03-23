namespace ManufacturerManagerAWS.Application.Services.ManufacturerStatus;

public interface IManufacturerStatusService
{
    Task<List<ManufacturerStatusDto>> GetManufacturerStatusesAsync();

    Task<ManufacturerStatusDto?> GetManufacturerStatusAsync(string statusId);
}
