using SQLite;

namespace BakingStore.Data.Entities;

public class BaseRecipe
{
    public BaseRecipe()
    {
    }
    public BaseRecipe(BaseRecipe src)
    {
        Id = src.Id;
        Name = src.Name;
        Qty = src.Qty;
    }
    [PrimaryKey]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Qty { get; set; }
}
