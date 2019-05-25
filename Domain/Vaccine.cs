using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Vaccine:BaseEntity
    {
        public string VaccineName { get; set; }
        public ICollection<HealthCardVaccine> VaccineHealthCards { get; set; }
    }
}
