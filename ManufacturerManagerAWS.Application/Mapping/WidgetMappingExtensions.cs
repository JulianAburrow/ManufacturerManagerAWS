namespace ManufacturerManagerAWS.Application.Mapping;

public static class WidgetMappingExtensions
{
    public static WidgetDetailsDto ToDto(this WidgetModel model) => new()
    {
        WidgetId = model.WidgetId,
        Name = model.Name,
        ManufacturerId = model.ManufacturerId,
        ColourId = model.ColourId,
        ColourJustificationId = model.ColourJustificationId,
        StatusId = model.StatusId,
        CostPrice = model.CostPrice,
        RetailPrice = model.RetailPrice,
        StockLevel = model.StockLevel,
    };

    public static WidgetModel ToModel(this CreateWidgetRequest request) => new()
    {
        WidgetId = $"WIDGET#{Guid.NewGuid()}",
        Name = request.Name,
        ManufacturerId = request.ManufacturerId,
        ColourId = request.ColourId,
        ColourJustificationId = request.ColourJustificationId,
        StatusId = request.StatusId,
        CostPrice = request.CostPrice,
        RetailPrice = request.RetailPrice,
        StockLevel = request.StockLevel,
    };

    public static WidgetModel ToModel(this UpdateWidgetRequest request) => new()
    {
        WidgetId = request.WidgetId,
        Name = request.Name,
        ManufacturerId = request.ManufacturerId,
        ColourId = request.ColourId,
        ColourJustificationId = request.ColourJustificationId,
        StatusId = request.StatusId,
        CostPrice = request.CostPrice,
        RetailPrice = request.RetailPrice,
        StockLevel = request.StockLevel,
    };
}
