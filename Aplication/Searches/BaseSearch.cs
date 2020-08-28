using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Searches
{
    public  class BaseSearch:PaginateSearch
    {

        public string Keyword { get; set; }

        public bool? OnlyActive { get; set; }
        
    }
}
