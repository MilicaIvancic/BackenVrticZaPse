using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Payment:BaseEntity
    {
        public decimal PaidMoney { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
