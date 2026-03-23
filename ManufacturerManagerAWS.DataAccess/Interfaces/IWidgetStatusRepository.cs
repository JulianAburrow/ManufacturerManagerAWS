namespace ManufacturerManagerAWS.DataAccess.Interfaces;

public interface IWidgetStatusRepository
{
    Task<WidgetStatusModel?> GetWidgetStatusAsync(string statusId);

    Task<IEnumerable<WidgetStatusModel>> GetWidgetStatusesAsync();

    Task<WidgetStatusModel?> GetWidgetStatusByName(string statusName);
}
