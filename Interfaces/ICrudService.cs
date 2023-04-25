using BakingStore.Pagination;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakingStore.Interfaces;

public interface ICrudService<T> 
    where T : new()
{
    public Task AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    public Task<PageResult<T>> FetchPageAsync(PageRequest<T> pageRequest);
}
