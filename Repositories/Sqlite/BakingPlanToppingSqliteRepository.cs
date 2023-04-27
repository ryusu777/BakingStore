using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Repositories.Interfaces;
using BakingStore.Services;

namespace BakingStore.Repositories.Sqlite;

public class BakingPlanToppingSqliteRepository : SqliteCrudService<BakingPlanTopping>, IBakingPlanToppingRepository
{
    public BakingPlanToppingSqliteRepository(BakingStoreSqliteContext context, EntityService entityService) : base(context, entityService)
    {
    }
}
