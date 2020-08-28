using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Paginate
{
    public class PaginateResponse<T>
    {
        public int PerPage { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
