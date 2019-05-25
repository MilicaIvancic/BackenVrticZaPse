using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PriceService:BaseEntity
    {
        public decimal Price { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public DateTime? EndAt { get; set; }

    }
}
