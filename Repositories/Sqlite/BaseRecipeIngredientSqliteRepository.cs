using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Pagination;
using BakingStore.Repositories.Interfaces;
using BakingStore.Services;

namespace BakingStore.Repositories.Sqlite;

public class VBaseRecipeIngredient
{
	public int Id { get; set; }
	public int BaseRecipeId { get; set; }
	public int IngredientId { get; set; }
	public float IngredientQty { get; set; }
	public string IngredientName { get; set; }
	public string UomCode { get; set; }
	public float AvailableStock { get; set; }
}
public class BaseRecipeIngredientSqliteRepository : SqliteCrudService<BaseRecipeIngredient>, IBaseRecipeIngredientRepository
{
    public BaseRecipeIngredientSqliteRepository(BakingStoreSqliteContext context, EntityService entityService) : base(context, entityService)
    {
    }

	public async Task<ICollection<BaseRecipeIngredient>> FetchJoinPageAsync(int baseRecipeId)
	{
        ICollection<VBaseRecipeIngredient> qryResult = await (await _context.Set<VBaseRecipeIngredient>()).Where(e => e.BaseRecipeId == baseRecipeId).ToListAsync();

        return qryResult.Select(e => new BaseRecipeIngredient
        {
            IngredientId = e.IngredientId,
            Id = e.Id,
            BaseRecipeId = e.BaseRecipeId,
            IngredientQty = e.IngredientQty,
            Ingredient = new Ingredient
            {
                Id = e.IngredientId,
                AvailableStock = e.AvailableStock,
                Name = e.IngredientName,
                UomCode = e.UomCode
            }
        }).ToList();
	}
}
