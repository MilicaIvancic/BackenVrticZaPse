using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Address:BaseEntity
    {
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


    }
}
