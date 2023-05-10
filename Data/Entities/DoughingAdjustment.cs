using SQLite;
namespace BakingStore.Data.Entities;

public class DoughingAdjustment : BaseEntity
{
    public DoughingAdjustment()
    {
    }
    public DoughingAdjustment(DoughingAdjustment src)
        : base(src)
    {
        BakingPlanId = src.BakingPlanId;
        IngredientId = src.IngredientId;
        Mode = src.Mode;
        Qty = src.Qty;
    }
    [Indexed]
    public int BakingPlanId { get; set; }
    [Indexed]
    public int IngredientId { get; set; }
    public string Mode { get; set; }
    public int Qty { get; set; }
}
