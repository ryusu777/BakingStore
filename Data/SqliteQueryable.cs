using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakingStore.Data;

public class SqliteQueryable<T> : AsyncTableQuery<T>
    where T : new()
{
    private Expression _mapper;
    private TableQuery<T> _innerQuery;
    public SqliteQueryable(TableQuery<T> innerQuery) : base(innerQuery)
    {
        _innerQuery = innerQuery;
    }

    public SqliteQueryable<T> SetMapper(Expression mapper)
    {
        _mapper = mapper;
        return this;
    }
    public SqliteQueryable<M> Select<M>(Expression<Func<T, M>> mapper)
        where M : new()
    {
        TableQuery<M> newQuery = _innerQuery.Clone<M>();
        return new SqliteQueryable<M>(newQuery).SetMapper(mapper);
    }
    public new SqliteQueryable<T> Where(Expression<Func<T, bool>> predExpr)
    {
        return new SqliteQueryable<T>(_innerQuery.Where(predExpr));
    }
    public new SqliteQueryable<T> Skip(int n)
    {
        return new SqliteQueryable<T>(_innerQuery.Skip(n));
    }
    public new SqliteQueryable<T> Take(int n)
    {
        return new SqliteQueryable<T>(_innerQuery.Take(n));
    }
}
