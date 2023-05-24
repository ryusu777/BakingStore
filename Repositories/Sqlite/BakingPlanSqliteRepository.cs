using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Pagination;
using BakingStore.Repositories.Interfaces;
using BakingStore.Services;

namespace BakingStore.Repositories.Sqlite;

public class BakingPlanSqliteRepository : SqliteCrudService<BakingPlan>, IBakingPlanRepository
{
	private readonly IBaseRecipeRepository _recipeRepository;
	private readonly IBaseRecipeIngredientRepository _recipeIngredientRepository;
	private readonly IIngredientRepository _ingredientRepository;
    public BakingPlanSqliteRepository(
		BakingStoreSqliteContext context, 
		EntityService entityService, 
		IBaseRecipeRepository recipeRepository, 
		IBaseRecipeIngredientRepository recipeIngredientRepository,
		IIngredientRepository ingredientRepository) : base(context, entityService)
    {
		_recipeRepository = recipeRepository;
		_recipeIngredientRepository = recipeIngredientRepository;
		_ingredientRepository = ingredientRepository;
    }

	public async Task<ICollection<BakingPlan>> FetchBakingPlaningData(DateTime date)
	{
		DateTime datePlusOne = date.AddDays(1);
		ICollection<BakingPlan> result = (await FetchPageAsync(new PageRequest<BakingPlan>
			{
				Page = 1,
				RowsPerPage = 100
			}
		)).Data;
		foreach (BakingPlan e in result)
		{
			e.Recipe = await _recipeRepository.FirstOrDefaultAsync(r => r.Id == e.BaseRecipeId);
			e.Recipe.Ingredients = (await _recipeIngredientRepository.FetchPageAsync(new PageRequest<BaseRecipeIngredient>
			{
				Page = 1,
				RowsPerPage = 100
			}.Where(r => r.BaseRecipeId == e.Recipe.Id))).Data;
			foreach (BaseRecipeIngredient ri in e.Recipe.Ingredients)
			{
				ri.Ingredient = await _ingredientRepository.FirstOrDefaultAsync(i => i.Id == ri.IngredientId);
			}
		}

		return result;
	}

	public Task<ICollection<DoughingAdjustment>> FetchDoughingAdjustmentData(string date)
	{
		throw new NotImplementedException();
	}
}
