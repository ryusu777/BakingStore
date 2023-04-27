using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Repositories.Interfaces;
using BakingStore.Services;

namespace BakingStore.Repositories.Sqlite;

public class BakingPlanSqliteRepository : SqliteCrudService<BakingPlan>, IBakingPlanRepository
{
    public BakingPlanSqliteRepository(BakingStoreSqliteContext context, EntityService entityService) : base(context, entityService)
    {
    }
}
