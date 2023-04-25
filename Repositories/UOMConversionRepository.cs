using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Services;

namespace BakingStore.Repositories;

public class UOMConversionRepository : SqliteCrudService<UOMConversion>
{
    public UOMConversionRepository(BakingStoreSqliteContext context, EntityService entityService) : base(context, entityService)
    {
    }
}
