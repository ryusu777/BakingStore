using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Repositories.Interfaces;
using BakingStore.Services;

namespace BakingStore.Repositories.Sqlite;

public class IngredientSqliteRepository : SqliteCrudService<Ingredient>, IIngredientRepository
{
    public IngredientSqliteRepository(BakingStoreSqliteContext context, EntityService entityService) : base(context, entityService)
    {
    }
}
