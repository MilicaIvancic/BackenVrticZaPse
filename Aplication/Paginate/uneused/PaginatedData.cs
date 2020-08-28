using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplication.Paginate
{
    public class PaginatedData<T>
    {
        public IQueryable<T> Query { get; private set; }
        public int Count { get; private set; }

        public PaginatedData(IQueryable<T> query, int count)
        {
            Query = query;
            Count = count;
        }

    }
}
