using SQLite;

namespace BakingStore.Data.Entities;

public class BakingPlan
{
    public BakingPlan()
    {
    }
    public BakingPlan(BakingPlan src)
    {
        Id = src.Id;
        BaseRecipeId = src.BaseRecipeId;
        BakingDate = src.BakingDate;
    }
    [PrimaryKey]
    public int Id { get; set; }
    public int BaseRecipeId { get; set; }
    public DateTime BakingDate { get; set; }
}
