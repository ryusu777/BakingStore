using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakingStore.Pagination;

public class PageResult<T>
{
    public PageResult()
    {
        Data = new List<T>();
    }
    public int Page { get; set; }
    public int RowsPerPage { get; set; }
    public int TotalRows { get; set; }
    public int TotalPage => TotalRows / Page;
    public ICollection<T> Data { get; set; }
}
