using SQLite;

namespace BakingStore.Data.Entities;

public class BaseRecipeIngredient : BaseEntity
{
    public BaseRecipeIngredient()
    {
    }
    public BaseRecipeIngredient(BaseRecipeIngredient src)
        : base(src)
    {
        BaseRecipeId = src.BaseRecipeId;
        IngredientId = src.IngredientId;
        IngredientQty = src.IngredientQty;
    }
    [Indexed]
    public int BaseRecipeId { get; set; }
    [Indexed]
    public int IngredientId { get; set; }
    public float IngredientQty { get; set; }

    [Ignore]
    public Ingredient Ingredient { get; set; }
}
