namespace ManufacturerManagerAWS.UserInterface.Shared.Components;

public partial class WidgetGridviewComponent
{
    [Parameter] public List<WidgetDetailsDto> Widgets { get; set; } = null!;

    private decimal TotalStockValue { get; set; }

    protected override void OnParametersSet()
    {
        GetTotalWidgetStockValue();
    }

    private void GetTotalWidgetStockValue()
    {
        TotalStockValue = 0;
        foreach (var widget in Widgets)
        {
            TotalStockValue += widget.StockLevel * widget.CostPrice;
        }
    }
}