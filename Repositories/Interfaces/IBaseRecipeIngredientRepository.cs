using BakingStore.Data.Entities;
using BakingStore.Interfaces;
using BakingStore.Pagination;

namespace BakingStore.Repositories.Interfaces;

public interface IBaseRecipeIngredientRepository : ICrudService<BaseRecipeIngredient>
{
	public Task<ICollection<BaseRecipeIngredient>> FetchJoinPageAsync(int baseRecipeId);
}
