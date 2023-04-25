using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Pagination;
using BakingStore.Repositories.Interfaces;
using BakingStore.Services;
using System.Linq.Expressions;

namespace BakingStore.Repositories.Sqlite;

public class UOMSqliteRepository : SqliteCrudService<UOM>, IUOMRepository
{
    public UOMSqliteRepository(BakingStoreSqliteContext context, EntityService entityService) : base(context, entityService)
    {
    }
}
