using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MedicineMedicalReport
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int MedicalReportId { get; set; }
        public MedicalReport MedicalReport { get; set; }
    }
}
