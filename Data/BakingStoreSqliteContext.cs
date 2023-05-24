using BakingStore.Data.Entities;
using BakingStore.Interfaces;
using BakingStore.Repositories.Sqlite;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakingStore.Data;

public class BakingStoreSqliteContext
{
    private SQLiteAsyncConnection? _asyncContext;

	public BakingStoreSqliteContext()
	{
	}
    public async Task AddAsync<T>(T entity)
    {
        await InitDb();
        await _asyncContext.InsertAsync(entity);
    }

    public async Task DeleteAsync<T>(T entity)
    {
        await InitDb();
        await _asyncContext.DeleteAsync(entity);
    }

    public async Task UpdateAsync<T>(T entity)
    {
        await InitDb();
        await _asyncContext.UpdateAsync(entity);
    }
    public async Task<SqliteQueryable<T>> Set<T>()
        where T : new()
    {
        await InitDb();
        return new SqliteQueryable<T>(_asyncContext.GetConnection().Table<T>());
    }

    public async Task<ICollection<M>> QueryAsync<M>(string query, params object[] args)
        where M : new()
    {
        var result = (await _asyncContext.QueryAsync<M>(query, args)).ToList();
        return (ICollection<M>)result;
    }
    async Task InitDb()
	{
		if (_asyncContext != null)
			return;

		_asyncContext = new SQLiteAsyncConnection(DbConfigurations.DatabasePath, DbConfigurations.Flags);
        await _asyncContext.ExecuteAsync("CREATE VIEW IF NOT EXISTS VBaseRecipeIngredient AS SELECT b.Id, b.BaseRecipeId, b.IngredientId, b.IngredientQty, i.Name as IngredientName, i.UomCode, i.AvailableStock FROM BaseRecipeIngredient b JOIN Ingredient i ON b.IngredientId = i.Id;");
		await _asyncContext.CreateTablesAsync(CreateFlags.None, 
            typeof(BakingPlan),
            typeof(BakingPlanTopping),
            typeof(BaseRecipe),
            typeof(BaseRecipeIngredient),
            typeof(DoughingAdjustment),
            typeof(Ingredient),
            typeof(Topping),
            typeof(FinishingAdjustment),
			typeof(UOM),
            typeof(UOMConversion),
            typeof(VBaseRecipeIngredient)
		);
	}
}
