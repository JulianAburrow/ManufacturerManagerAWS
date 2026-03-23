namespace ManufacturerManagerAWS.Application.Services.Widget;

public class WidgetService(
    IColourRepository colourRepository,
    IColourJustificationRepository colourJustificationRepository,
    IManufacturerRepository manufacturerRepository,
    IWidgetStatusRepository widgetStatusRepository,
    IWidgetRepository widgetRepository) : IWidgetService
{
    public async Task<WidgetDetailsDto> CreateWidgetAsync(CreateWidgetRequest request)
    {
        var model = request.ToModel();
        await widgetRepository.CreateWidgetAsync(model);
        return model.ToDto();
    }

    public async Task<WidgetDetailsDto?> GetWidgetDetailsAsync(string widgetId)
    {
        var widget = await widgetRepository.GetWidgetAsync(widgetId);
        if (widget is null)
            return null;

        var manufacturer = await manufacturerRepository.GetManufacturerAsync(widget.ManufacturerId);
        var colour = new ColourModel();
        if (widget.ColourId is not null)
        {
            colour = await colourRepository.GetColourAsync(widget.ColourId);
        }
        var colourJustification = new ColourJustificationModel();
        if (widget.ColourJustificationId is not null)
        {
            colourJustification = await colourJustificationRepository.GetColourJustificationAsync(widget.ColourJustificationId);
        }
        var status = await widgetStatusRepository.GetWidgetStatusAsync(widget.StatusId);

        return new WidgetDetailsDto
        {
            WidgetId = widget.WidgetId,
            Name = widget.Name,
            ManufacturerId = manufacturer?.ManufacturerId ?? "No manufacturer entered",
            ManufacturerName = manufacturer?.Name ?? "No manufacturer entered",
            ColourId = colour?.ColourId,
            ColourName = colour?.Name,
            ColourJustificationId = colourJustification?.ColourJustificationId,
            ColourJustificationJustification = colourJustification?.Justification,
            StatusId = widget.StatusId,
            StatusName = status?.Name ?? "No status entered",
            CostPrice = widget.CostPrice,
            RetailPrice = widget.RetailPrice,
            StockLevel = widget.StockLevel,
        };
    }

    public async Task<List<WidgetDetailsDto>> GetWidgetsAsync(IEnumerable<WidgetModel>? widgets = null)
    {
        widgets = widgets is not null ? widgets : await widgetRepository.GetWidgetsAsync();

        if (widgets is null)
            return [];

        var manufacturers = (await manufacturerRepository.GetManufacturersAsync())
            .ToDictionary(m => m.ManufacturerId);
        var colours = (await colourRepository.GetColoursAsync())
            .ToDictionary(c => c.ColourId);
        var colourJustifications = (await colourJustificationRepository.GetColourJustificationsAsync())
            .ToDictionary(c => c.ColourJustificationId);
        var statuses = (await widgetStatusRepository.GetWidgetStatusesAsync())
            .ToDictionary(s => s.WidgetStatusId);

        var results = new List<WidgetDetailsDto>();

        foreach (var widget in widgets)
        {
            results.Add(new WidgetDetailsDto
            {
                WidgetId = widget.WidgetId,
                Name = widget.Name,

                ManufacturerId = widget.ManufacturerId,
                ManufacturerName = manufacturers.TryGetValue(widget.ManufacturerId, out var m) ? m.Name : "No manufacturer chosen",

                ColourId = widget.ColourId,
                ColourName = widget.ColourId is not null
                    && colours.TryGetValue(widget.ColourId, out var c)
                        ? c.Name
                        : "No colour chosen",

                ColourJustificationId = widget.ColourJustificationId,
                ColourJustificationJustification = widget.ColourJustificationId is not null
                    && colourJustifications.TryGetValue(widget.ColourJustificationId, out var j)
                        ? j.Justification
                        : "No colour justification chosen",

                StatusId = widget.StatusId,
                StatusName = statuses.TryGetValue(widget.StatusId, out var s)
                    ? s.Name
                    : "No status chosen",

                CostPrice = widget.CostPrice,
                RetailPrice = widget.RetailPrice,
                StockLevel = widget.StockLevel,
            });
        }

        return results.OrderBy(w => w.Name).ToList();
    }

    public async Task<WidgetDetailsDto> UpdateWidgetAsync(UpdateWidgetRequest request)
    {
        await widgetRepository.DeleteWidgetAsync(request.WidgetId);
        
        var model = request.ToModel();
        await widgetRepository.UpdateWidgetAsync(model);
        return model.ToDto();
    }
}
