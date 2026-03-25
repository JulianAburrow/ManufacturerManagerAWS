namespace ManufacturerManagerAWS.Application.Services.Manufacturer;

public class ManufacturerService(
    IManufacturerRepository manufacturerRepository,
    IManufacturerStatusRepository manufacturerStatusRepository,
    ITransactionRepository transactionRepository,
    IWidgetRepository widgetManufacturerRepository,
    IWidgetStatusRepository widgetStatusRepository) : IManufacturerService
{
    public async Task<ManufacturerDetailsDto> CreateManufacturerAsync(CreateManufacturerRequest request)
    {
        var model = request.ToModel();
        await manufacturerRepository.CreateManufacturerAsync(model);
        return model.ToDto();
    }

    public async Task<ManufacturerDetailsDto?> GetManufacturerDetailsAsync(string manufacturerId)
    {
        var manufacturer = await manufacturerRepository.GetManufacturerAsync(manufacturerId);
        if (manufacturer is null)
            return null;

        var status = await manufacturerStatusRepository.GetManufacturerStatusAsync(manufacturer.StatusId);

        var widgets = await widgetManufacturerRepository.GetWidgetsByManufacturerAsync(manufacturerId);
        var statuses = await widgetStatusRepository.GetWidgetStatusesAsync();

        return new ManufacturerDetailsDto
        {
            ManufacturerId = manufacturer.ManufacturerId,
            Name = manufacturer.Name,
            StatusId = manufacturer.StatusId,
            StatusName = status?.Name ?? "No status entered",
            Widgets = widgets.Select(w =>
            {
                var widgetStatus = statuses.FirstOrDefault(s => s.WidgetStatusId == w.StatusId);

                return new WidgetDetailsDto
                {
                    WidgetId = w.WidgetId,
                    Name = w.Name,
                    StatusName = widgetStatus?.Name ?? "Unknown",
                    CostPrice = w.CostPrice,
                    RetailPrice = w.RetailPrice,
                    StockLevel = w.StockLevel,
                };
            }).ToList()
        };
    }

    public async Task<List<ManufacturerSummaryDto>> GetManufacturerSummariesAsync()
    {
        var manufactucturers = await manufacturerRepository.GetManufacturersAsync();

        var manufacturerSummaries = new List<ManufacturerSummaryDto>();

        foreach (var manufacturer in manufactucturers)
        {
            manufacturerSummaries.Add(new ManufacturerSummaryDto
            {
                ManufacturerId = manufacturer.ManufacturerId,
                Name = manufacturer.Name,
            });
        }

        return manufacturerSummaries.OrderBy(m => m.Name).ToList();
    }

    public async Task<List<ManufacturerWithWidgetCountDto>> GetManufacturersWithWidgetCountAsync(IEnumerable<ManufacturerModel>? manufacturers = null)
    {
        manufacturers = manufacturers is not null ? manufacturers : await manufacturerRepository.GetManufacturersAsync();

        if (manufacturers is null)
            return [];

        var results = new List<ManufacturerWithWidgetCountDto>();

        foreach (var manufacturer in manufacturers)
        {
            var widgetCount = await widgetManufacturerRepository.GetWidgetCountByManufacturerAsync(manufacturer.ManufacturerId);
            var manufacturerStatus = await manufacturerStatusRepository.GetManufacturerStatusAsync(manufacturer.StatusId);
            var manufacturerWithWidgetCountDto = new ManufacturerWithWidgetCountDto
            {
                ManufacturerId = manufacturer.ManufacturerId,
                Name = manufacturer.Name,
                StatusId = manufacturerStatus?.ManufacturerStatusId ?? "0",
                StatusName = manufacturerStatus?.Name ?? "Status not found",
                WidgetCount = widgetCount,
            };
            results.Add(manufacturerWithWidgetCountDto);
        }

        return results.OrderBy(m => m.Name).ToList();
    }

    public async Task<ManufacturerDetailsDto> UpdateManufacturerAsync(UpdateManufacturerRequest request)
    {
        const string Inactive = "inactive";

        var transactItems = new List<TransactWriteItem>();

        var manufacturerModel = request.ToModel();
        transactItems.Add(manufacturerRepository.BuildUpdateTransactItem(manufacturerModel));

        var manufacturerStatus = await manufacturerStatusRepository.GetManufacturerStatusAsync(manufacturerModel.StatusId);
        if (manufacturerStatus?.Name.Equals(Inactive, StringComparison.OrdinalIgnoreCase) == true)
        {
            var inactiveWidgetStatus = await widgetStatusRepository.GetWidgetStatusByName(Inactive);
            if (inactiveWidgetStatus is not null)
            {
                var manufacturerWidgets = await widgetManufacturerRepository.GetWidgetsByManufacturerAsync(manufacturerModel.ManufacturerId);

                foreach (var widget in manufacturerWidgets)
                {
                    widget.StatusId = inactiveWidgetStatus.WidgetStatusId;

                    transactItems.Add(widgetManufacturerRepository.BuildUpdateTransactItem(widget));
                }
            }
        }

        var requestItems = new TransactWriteItemsRequest
        {
            TransactItems = transactItems,
        };

        await transactionRepository.ExecuteTransactionAsync(transactItems);

        return manufacturerModel.ToDto();
    }
}
