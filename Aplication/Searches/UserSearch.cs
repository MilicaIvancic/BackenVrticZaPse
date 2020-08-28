using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Searches
{
    public class UserSearch:BaseSearch
    {
        public string CityName { get; set; }
        public int RoleId { get; set; }
        public bool? Deleted { get; set; }
    }
}
