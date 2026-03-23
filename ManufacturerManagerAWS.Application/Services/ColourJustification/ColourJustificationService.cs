using ManufacturerManagerAWS.Application.DTOs.ColourJustifications;

namespace ManufacturerManagerAWS.Application.Services.ColourJustification;

public class ColourJustificationService(
    IColourJustificationRepository colourJustificationRepository,
    IColourRepository colourRepository,
    IWidgetRepository widgetColourJustificationRepository,
    IWidgetStatusRepository widgetStatusRepository) : IColourJustificationService
{
    public async Task<ColourJustificationDetailsDto> CreateColourJustificationAsync(CreateColourJustificationRequest request)
    {
        var model = request.ToModel();
        await colourJustificationRepository.CreateColourJustificationAsync(model);
        return model.ToDto();
    }

    public async Task DeleteColourJustificationAsync(string colourJustificationId)
    {
        await colourJustificationRepository.DeleteColourJustificationAsync(colourJustificationId);
    }

    public async Task<ColourJustificationDetailsDto?> GetColourJustificationDetailsAsync(string colourJustificationId)
    {
        var colourJustification = await colourJustificationRepository.GetColourJustificationAsync(colourJustificationId);
        if (colourJustification == null)
            return null;

        // Get widgets for this object
        var widgets = await widgetColourJustificationRepository.GetWidgetsByColourJustificationAsync(colourJustificationId);
        foreach (var widget in widgets)
        {
            if (widget.ColourJustificationId is not null)
                widget.ColourJustification = await colourJustificationRepository.GetColourJustificationAsync(widget.ColourJustificationId);
            if (widget.ColourId is not null)
                widget.Colour = await colourRepository.GetColourAsync(widget.ColourId);
            var status = await widgetStatusRepository.GetWidgetStatusAsync(widget.StatusId)
                ?? throw new InvalidOperationException($"WidgetStatus '{widget.StatusId}' not found.");
            widget.Status = status;
        }

        return new ColourJustificationDetailsDto
        {
            ColourJustificationId = colourJustification.ColourJustificationId,
            Justification = colourJustification.Justification,
            Widgets = widgets.Select(w => new WidgetSummaryDto
            {
                WidgetId = w.WidgetId,
                Name = w.Name,
                ColourId = w.ColourId,
                ColourName = w.Colour?.Name ?? "None chosen",
                ColourJustificationId = w.ColourJustificationId,
                ColourJustificationJustification = w.ColourJustification?.Justification ?? "None chosen",
                StatusId = w.StatusId,
                StatusName = w.Status.Name,
            }).ToList()
        };
    }

    public async Task<List<ColourJustificationDetailsDto>> GetColourJustificationDetailsListAsync()
    {
        var colourJustifications = await colourJustificationRepository.GetColourJustificationsAsync();

        var colourJustificationDetailsList = new List<ColourJustificationDetailsDto>();

        foreach (var colourJustification in colourJustifications)
        {
            colourJustificationDetailsList.Add(new ColourJustificationDetailsDto
            {
                ColourJustificationId = colourJustification.ColourJustificationId,
                Justification = colourJustification.Justification,
            });
        }

        return colourJustificationDetailsList.OrderBy(c => c.Justification).ToList();
    }

    public async Task<List<ColourJustificationWithWidgetCountDto>> GetColourJustificationsWithWidgetCountAsync(IEnumerable<ColourJustificationModel>? colourJustifications = null)
    {
        colourJustifications = colourJustifications is not null ? colourJustifications : await colourJustificationRepository.GetColourJustificationsAsync();

        if (colourJustifications is null)
            return [];

        var results = new List<ColourJustificationWithWidgetCountDto>();

        foreach (var colourJustification in colourJustifications)
        {
            var widgetCount = await widgetColourJustificationRepository.GetWidgetCountByColourJustificationAsync(colourJustification.ColourJustificationId);
            var colourJustificationWithWidgetCountDto = new ColourJustificationWithWidgetCountDto
            {
                ColourJustificationId = colourJustification.ColourJustificationId,
                Justification = colourJustification.Justification,
                WidgetCount = widgetCount,
            };
            results.Add(colourJustificationWithWidgetCountDto);
        }

        return results.OrderBy(c => c.Justification).ToList();
    }

    public async Task<ColourJustificationDetailsDto> UpdateColourJustificationAsync(UpdateColourJustificationRequest request)
    {
        var model = request.ToModel();
        await colourJustificationRepository.UpdateColourJustificationAsync(model);
        return model.ToDto();
    }
}
