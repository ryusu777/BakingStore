using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Repositories.Interfaces;
using BakingStore.Services;

namespace BakingStore.Repositories.Sqlite;

public class FinishingAdjustmentSqliteRepository : SqliteCrudService<FinishingAdjustment>, IFinishingAdjustmentRepository
{
    public FinishingAdjustmentSqliteRepository(BakingStoreSqliteContext context, EntityService entityService) : base(context, entityService)
    {
    }
}
