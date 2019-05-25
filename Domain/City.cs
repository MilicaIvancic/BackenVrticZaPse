using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class City:BaseEntity
    {
        public string CityName { get; set; }
        public int ZipCode { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
