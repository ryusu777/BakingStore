using SQLite;

namespace BakingStore.Data.Entities;

public class Ingredient
{
    public Ingredient()
    {
    }
    public Ingredient(Ingredient src)
    {
        Id = src.Id;
        Name = src.Name;
        UOMCode = src.UOMCode;
        AvailableStock = src.AvailableStock;
    }
    [PrimaryKey]
    public int Id { get; set; }
    public string Name { get; set; }
    public string UOMCode { get; set; }
    public float AvailableStock { get; set; }
}
