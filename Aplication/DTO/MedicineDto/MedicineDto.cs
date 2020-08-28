using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTO.MedicineDto
{
    public class MedicineDto:BaseDto
    {
        public string MedicineName { get; set; }
        public string Description { get; set; }
        public bool IsFre { get; set; }
    }
}
