using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Aplication.DTO.MedicineDto
{
    public class MedicineDogInsertDto
    {
        [Required]
        public int DogId { get; set; }
        [Required]
        public int VeterinianId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MedicineId { get; set; }
       
        [Required]
        public DateTime EndDate { get; set; }
    }
}
