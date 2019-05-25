using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Searches
{
    public class RoleSearch
    {
        public string Keyword { get; set; }

        public bool? OnlyActive { get; set; }
        public bool? Deleted { get; set; }

    }
}
