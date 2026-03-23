namespace ManufacturerManagerAWS.UserInterface.Models;

public class WidgetDisplayModel
{
    [Required(ErrorMessage = "{0} is required")]
    public string Name { get; set; } = string.Empty;

    [NotPleaseSelectOrEmpty]
    [Display(Name = "Manufacturer")]
    public string ManufacturerId { get; set; } = string.Empty;

    public string ManufacturerName { get; set; } = string.Empty;

    public string? ColourId { get; set; }

    public string? ColourName { get; set; }

    public string? ColourJustificationId { get; set; } = string.Empty;

    public string? ColourJustificationJustification { get; set; } = string.Empty;

    [NotPleaseSelectOrEmpty]
    [Display(Name = "Status")]
    public string StatusId {  get; set; } = string.Empty;

    public string StatusName { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "Cost Price")]
    public decimal CostPrice { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name ="Retail Price")]
    public decimal RetailPrice { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "Stock Level")]
    public int StockLevel { get; set; }
}
