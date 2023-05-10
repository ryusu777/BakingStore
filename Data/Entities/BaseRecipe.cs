using SQLite;

namespace BakingStore.Data.Entities;

public class BaseRecipe : BaseEntity
{
    public BaseRecipe()
    {
    }
    public BaseRecipe(BaseRecipe src)
        : base(src)
    {
        Name = src.Name;
        ProductResultQty = src.ProductResultQty;
    }
    public string Name { get; set; }
    public int ProductResultQty { get; set; }
    [Ignore]
    public bool ShowDetail { get; set; } = false;
}
