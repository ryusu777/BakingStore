using SQLite;

namespace BakingStore.Data.Entities;

public class BakingPlanTopping
{
    public BakingPlanTopping()
    {
    }
    public BakingPlanTopping(BakingPlanTopping src)
    {
        BakingPlanId = src.BakingPlanId;
        ToppingId = src.ToppingId;
        Qty = src.Qty;
    }
    [PrimaryKey]
    public int BakingPlanId { get; set; }
    [PrimaryKey]
    public int ToppingId { get; set; }
    public int Qty { get; set; }
}
