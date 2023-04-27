using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Repositories.Interfaces;
using BakingStore.Services;

namespace BakingStore.Repositories.Sqlite;

public class DoughingAdjustmentSqliteRepository : SqliteCrudService<DoughingAdjustment>, IDoughingAdjustmentRepository
{
    public DoughingAdjustmentSqliteRepository(BakingStoreSqliteContext context, EntityService entityService) : base(context, entityService)
    {
    }
}
