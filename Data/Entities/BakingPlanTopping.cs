using SQLite;

namespace BakingStore.Data.Entities;

public class BakingPlanTopping : BaseEntity
{
    public BakingPlanTopping()
    {
    }
    public BakingPlanTopping(BakingPlanTopping src)
        : base(src)
    {
        BakingPlanId = src.BakingPlanId;
        ToppingId = src.ToppingId;
        Qty = src.Qty;
    }
    [Indexed]
    public int BakingPlanId { get; set; }
    [Indexed]
    public int ToppingId { get; set; }
    public int Qty { get; set; }
}
