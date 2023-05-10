using SQLite;

namespace BakingStore.Data.Entities;

public class FinishingAdjustment : BaseEntity
{
    public FinishingAdjustment()
    {
    }
    public FinishingAdjustment(FinishingAdjustment src)
        : base(src)
    {
        BakingPlanId = src.BakingPlanId;
        ToppingId = src.ToppingId;
        Mode = src.Mode;
        Qty = src.Qty;
    }
    [Indexed]
    public int BakingPlanId { get; set; }
    [Indexed]
    public int ToppingId { get; set; }
    public string Mode { get; set; }
    public int Qty { get; set; }
}
