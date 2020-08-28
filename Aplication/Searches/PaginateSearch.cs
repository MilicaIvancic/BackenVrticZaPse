using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Searches
{
    public abstract class PaginateSearch
    {
        public int PerPage { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
