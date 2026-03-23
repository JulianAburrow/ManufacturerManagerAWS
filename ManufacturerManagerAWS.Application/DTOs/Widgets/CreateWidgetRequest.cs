namespace ManufacturerManagerAWS.Application.DTOs.Widgets;

public class CreateWidgetRequest
{
    public string Name { get; set; } = default!;

    public string ManufacturerId { get; set; } = default!;

    public string? ColourId { get; set; } = default!;

    public string? ColourJustificationId { get; set; } = default!;

    public string StatusId { get; set; } = default!;

    public decimal CostPrice { get; set; }

    public decimal RetailPrice { get; set; }

    public int StockLevel { get; set; }
}
