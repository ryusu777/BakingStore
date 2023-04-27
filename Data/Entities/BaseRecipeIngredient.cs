using SQLite;

namespace BakingStore.Data.Entities;

public class BaseRecipeIngredient
{
    public BaseRecipeIngredient()
    {
    }
    public BaseRecipeIngredient(BaseRecipeIngredient src)
    {
        BaseRecipeId = src.BaseRecipeId;
        IngredientId = src.IngredientId;
        IngredientQty = src.IngredientQty;
    }
    [PrimaryKey]
    public int BaseRecipeId { get; set; }
    [PrimaryKey]
    public int IngredientId { get; set; }
    public float IngredientQty { get; set; }
}
