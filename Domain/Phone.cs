using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Phone:BaseEntity
    {
        public string PhoneNumer { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
