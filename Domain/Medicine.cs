using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Medicine:BaseEntity
    {
        public string MedicineName { get; set; }
        public bool IsFree { get; set; }
        public string Description { get; set; }
        public ICollection<MedicineMedicalReport> MedicineMedicalReports{ get; set; }
    }
}
