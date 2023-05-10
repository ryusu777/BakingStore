using BakingStore.Data.Entities;

namespace BakingStore.Services;

public static class LabelService
{
    public static Func<UOM, string> UOMLabel = (e) => e.UomCode + " - " + e.UomDesc;
    public static Func<Ingredient, string> IngredientLabel = (e) =>
        e.Name + ", Available: " + e.AvailableStock + " " + e.UomCode;
}
