namespace ManufacturerManagerAWS.Application.Services.ManufacturerStatus;

public class ManufacturerStatusService(
    IManufacturerStatusRepository manufacturerStatusRepository) : IManufacturerStatusService
{
    public async Task<ManufacturerStatusDto?> GetManufacturerStatusAsync(string statusId)
    {
        var manufacturerStatus = await manufacturerStatusRepository.GetManufacturerStatusAsync(statusId);
        if (manufacturerStatus is null)
            return null;

        return new ManufacturerStatusDto
        {
            ManufacturerStatusId = manufacturerStatus.ManufacturerStatusId,
            Name = manufacturerStatus.Name,
        };
    }

    public async Task<List<ManufacturerStatusDto>> GetManufacturerStatusesAsync()
    {
        var manufacturerStatuses = await manufacturerStatusRepository.GetManufacturerStatusesAsync();

        return manufacturerStatuses.Select(m => new ManufacturerStatusDto
        {
            ManufacturerStatusId = m.ManufacturerStatusId,
            Name = m.Name,
        })
        .OrderBy(m => m.Name)
        .ToList();
    }
}
