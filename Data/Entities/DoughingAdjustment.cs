using SQLite;
namespace BakingStore.Data.Entities;

public class DoughingAdjustment
{
    public DoughingAdjustment()
    {
    }
    public DoughingAdjustment(DoughingAdjustment src)
    {
        BakingPlanId = src.BakingPlanId;
        IngredientId = src.IngredientId;
        Mode = src.Mode;
        Qty = src.Qty;
    }
    [PrimaryKey]
    public int BakingPlanId { get; set; }
    [PrimaryKey]
    public int IngredientId { get; set; }
    public string Mode { get; set; }
    public int Qty { get; set; }
}
