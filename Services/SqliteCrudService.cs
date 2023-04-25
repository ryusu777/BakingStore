using BakingStore.Data;
using BakingStore.Interfaces;
using BakingStore.Pagination;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BakingStore.Services;

public class SqliteCrudService<T> : ICrudService<T>
    where T : new()
{
    BakingStoreSqliteContext _context;
    EntityService _entityService;
    public SqliteCrudService(BakingStoreSqliteContext context, EntityService entityService)
    {
        _context = context;
        _entityService = entityService;
    }
    public async Task AddAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        await _context.DeleteAsync(entity);
    }
	public async Task UpdateAsync(T entity)
    {
        await _context.UpdateAsync(entity);
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) 
    {
        Type entityType = _entityService.GetEntityClass<T>();
        MethodInfo setMethod = typeof(BakingStoreSqliteContext).GetMethods().FirstOrDefault(e => e.Name == "Set").MakeGenericMethod(entityType);

        object qry = Convert.ChangeType(setMethod.Invoke(_context, null), typeof(AsyncTableQuery<>).MakeGenericType(entityType));
        MethodInfo firstOrDefaultMethod = typeof(AsyncTableQuery<>).GetMethod("FirstOrDefaultAsync");

        dynamic awaitable = firstOrDefaultMethod.Invoke(qry, new object[] { predicate });
        await awaitable;
        return awaitable.GetAwaiter().GetResult();
    }

	public async Task<PageResult<T>> FetchPageAsync(PageRequest<T> pageRequest)
    {
        AsyncTableQuery<T> qry = await _context.Set<T>();

        pageRequest.Page = pageRequest.Page > 0 ? pageRequest.Page : 1;
        pageRequest.RowsPerPage = pageRequest.RowsPerPage > 0 ? pageRequest.RowsPerPage : 5;

        ICollection<T> entityResult = await qry
            .Where(pageRequest.WhereClause)
            .Skip((pageRequest.Page - 1) * pageRequest.RowsPerPage)
            .Take(pageRequest.RowsPerPage)
            .ToListAsync();

        return new()
        {
            Page = pageRequest.Page,
            RowsPerPage = pageRequest.RowsPerPage,
            Data = entityResult,
            TotalRows = await qry.CountAsync()
        };
    }

}
