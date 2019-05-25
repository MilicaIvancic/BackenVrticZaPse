using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DogHeat:BaseEntity
    {
        public int DogId { get; set; }
        public Dog Dog { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
