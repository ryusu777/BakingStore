using BakingStore.Data.Entities;
using BakingStore.Interfaces;
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
    public async Task<AsyncTableQuery<T>> Set<T>()
        where T : new()
    {
        await InitDb();
        return _asyncContext.Table<T>();
    }
    async Task InitDb()
	{
		if (_asyncContext != null)
			return;

		_asyncContext = new SQLiteAsyncConnection(DbConfigurations.DatabasePath, DbConfigurations.Flags);
		await _asyncContext.CreateTablesAsync(CreateFlags.None, 
			typeof(UOM)
		);
	}
}
