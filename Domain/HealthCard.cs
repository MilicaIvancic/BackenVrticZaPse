using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HealthCard :BaseEntity
    {
        public int CardNumer { get; set; }
        public int DogId { get; set; }
        public Dog Dog { get; set; }
        public ICollection<HealthCardVaccine> HelthCardVaccines { get; set; }
    }
}
