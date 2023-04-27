using BakingStore.Data;
using BakingStore.Interfaces;
using BakingStore.Pagination;
using SQLite;
using System.Linq.Expressions;
using System.Reflection;

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
        return await (await _context.Set<T>()).FirstOrDefaultAsync(predicate);
    }

	public async Task<PageResult<T>> FetchPageAsync(PageRequest<T> pageRequest)
    {
        SqliteQueryable<T> qry = await _context.Set<T>();

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
