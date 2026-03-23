namespace ManufacturerManagerAWS.DataAccess.Interfaces;

public interface IManufacturerStatusRepository
{
    Task<ManufacturerStatusModel?> GetManufacturerStatusAsync(string statusId);

    Task<IEnumerable<ManufacturerStatusModel>> GetManufacturerStatusesAsync();
}
