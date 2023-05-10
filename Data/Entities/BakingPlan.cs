using SQLite;

namespace BakingStore.Data.Entities;

public class BakingPlan : BaseEntity
{
    public BakingPlan()
    {
    }
    public BakingPlan(BakingPlan src)
        : base(src)
    {
        BaseRecipeId = src.BaseRecipeId;
        BakingDate = src.BakingDate;
    }
    public int BaseRecipeId { get; set; }
    public DateTime BakingDate { get; set; }
}
