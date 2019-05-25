using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Payout : BaseEntity
    {
        public decimal TakenMoney { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
