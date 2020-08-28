using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Aplication.DTO.DogDto
{
    public class UpisPsaMesecnoDto
    {
        [Required]
        public int DogId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public decimal Money { get; set; }
    }
}
