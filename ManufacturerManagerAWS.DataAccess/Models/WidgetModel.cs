namespace ManufacturerManagerAWS.DataAccess.Models;

[DynamoDBTable("ManufacturerManager_Widget")]
public class WidgetModel
{
    [DynamoDBHashKey]
    public string WidgetId { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string ManufacturerId { get; set; } = default!;

    public string? ColourId { get; set; }

    public string? ColourJustificationId { get; set; }

    public string StatusId { get; set; } = default!;

    public decimal CostPrice { get; set; }

    public decimal RetailPrice { get; set; }

    public int StockLevel { get; set; }

    [DynamoDBIgnore]
    public ColourModel? Colour { get; set; }

    [DynamoDBIgnore]
    public ColourJustificationModel? ColourJustification { get; set; }

    [DynamoDBIgnore]
    public WidgetStatusModel Status { get; set; } = null!;
}
