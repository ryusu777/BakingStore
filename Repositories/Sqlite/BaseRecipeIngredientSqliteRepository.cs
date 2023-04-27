using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Repositories.Interfaces;
using BakingStore.Services;

namespace BakingStore.Repositories.Sqlite;

public class BaseRecipeIngredientSqliteRepository : SqliteCrudService<BaseRecipeIngredient>, IBaseRecipeIngredientRepository
{
    public BaseRecipeIngredientSqliteRepository(BakingStoreSqliteContext context, EntityService entityService) : base(context, entityService)
    {
    }
}
