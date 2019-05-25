using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MedicalReport:BaseEntity
    {
        public string Description { get; set; }
        public int VeterinarianId { get; set; }
        public User Veterinarian { get; set; }
        public int DogId { get; set; }

        public Dog Dog { get; set; }
        public ICollection<MedicineMedicalReport> MedicalReportMedicines { get; set; }

    }
}
