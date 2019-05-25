using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HealthCardVaccine:BaseEntity
    {
        public int VaccineId { get; set; }
        public int HealthCardId { get; set; }
        public Vaccine Vaccine{ get; set; }
        public HealthCard HealthCard { get; set; }
    }
}
