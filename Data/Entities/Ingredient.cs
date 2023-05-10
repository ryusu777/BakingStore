using SQLite;

namespace BakingStore.Data.Entities;

public class Ingredient : BaseEntity
{
    public Ingredient()
    {
    }
    public Ingredient(Ingredient src)
        : base(src)
    {
        Name = src.Name;
        UomCode = src.UomCode;
        AvailableStock = src.AvailableStock;
    }
    public string Name { get; set; }
    public string UomCode { get; set; }
    public float AvailableStock { get; set; }
}
