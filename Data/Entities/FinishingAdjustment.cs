using SQLite;

namespace BakingStore.Data.Entities;

public class FinishingAdjustment
{
    public FinishingAdjustment()
    {
    }
    public FinishingAdjustment(FinishingAdjustment src)
    {
        BakingPlanId = src.BakingPlanId;
        ToppingId = src.ToppingId;
        Mode = src.Mode;
        Qty = src.Qty;
    }
    [PrimaryKey]
    public int BakingPlanId { get; set; }
    [PrimaryKey]
    public int ToppingId { get; set; }
    public string Mode { get; set; }
    public int Qty { get; set; }
}
