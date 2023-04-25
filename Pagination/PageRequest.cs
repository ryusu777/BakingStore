using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakingStore.Pagination;

public class PageRequest<T>
{
    public Expression<Func<T, bool>> WhereClause { get; set; } = e => true;
    public int Page { get; set; } = 1;
    public int RowsPerPage { get; set; } = 5;
    public PageRequest<T> Where(Expression<Func<T, bool>> predicate)
    {
        WhereClause = predicate;
        return this;
    }
}
