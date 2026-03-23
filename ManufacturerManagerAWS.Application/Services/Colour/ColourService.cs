namespace ManufacturerManagerAWS.Application.Services.Colour;

public class ColourService(
    IColourRepository colourRepository,
    IColourJustificationRepository colourJustificationRepository,
    IWidgetRepository widgetColourRepository,
    IWidgetStatusRepository widgetStatusRepository) : IColourService
{
    public async Task<ColourDetailsDto> CreateColourAsync(CreateColourRequest request)
    {
        var model = request.ToModel();
        await colourRepository.CreateColourAsync(model);
        return model.ToDto();
    }

    public async Task DeleteColourAsync(string colourId)
    {
        await colourRepository.DeleteColourAsync(colourId);
    }

    public async Task<ColourDetailsDto?> GetColourDetailsAsync(string colourId)
    {
        var colour = await colourRepository.GetColourAsync(colourId);
        if (colour is null)
            return null;

        // Get widgets for this colour
        var widgets = await widgetColourRepository.GetWidgetsByColourAsync(colourId);
        foreach (var widget in widgets)
        {
            if (widget.ColourId is not null)
                widget.Colour = await colourRepository.GetColourAsync(widget.ColourId);
            if (widget.ColourJustificationId is not null)
                widget.ColourJustification = await colourJustificationRepository.GetColourJustificationAsync(widget.ColourJustificationId);
            var status = await widgetStatusRepository.GetWidgetStatusAsync(widget.StatusId)
                ?? throw new InvalidOperationException($"WidgetStatus '{widget.StatusId}' not found.");
            widget.Status = status;
        }

        return new ColourDetailsDto
        {
            ColourId = colour.ColourId,
            Name = colour.Name,
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
            }).ToList(),
        };
    }

    public async Task<List<ColourDetailsDto>> GetColourDetailsListAsync()
    {
        var colours = await colourRepository.GetColoursAsync();

        var colourDetailsList = new List<ColourDetailsDto>();

        foreach (var colour in colours)
        {
            colourDetailsList.Add(new ColourDetailsDto
            {
                ColourId = colour.ColourId,
                Name = colour.Name,
            });
        }

        return colourDetailsList.OrderBy(c => c.Name).ToList();
    }

    public async Task<List<ColourWithWidgetCountDto>> GetColoursWithWidgetCountAsync(IEnumerable<ColourModel>? colours = null)
    {
        colours = colours is not null ? colours : await colourRepository.GetColoursAsync();

        if (colours is null)
            return [];

        var results = new List<ColourWithWidgetCountDto>();

        foreach (var colour in colours)
        {
            var widgetCount = await widgetColourRepository.GetWidgetCountByColourAsync(colour.ColourId);
            var colourWithWidgetCountDto = new ColourWithWidgetCountDto
            {
                ColourId = colour.ColourId,
                Name = colour.Name,
                WidgetCount = widgetCount,
            };
            results.Add(colourWithWidgetCountDto);
        }

        return results.OrderBy(c => c.Name).ToList();
    }

    public async Task<ColourDetailsDto> UpdateColourAsync(UpdateColourRequest request)
    {
        var model = request.ToModel();
        await colourRepository.UpdateColourAsync(model);
        return model.ToDto();
    }
}
