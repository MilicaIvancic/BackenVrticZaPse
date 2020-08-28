using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.DTO.ServiceDto
{
    public class AddServiceDto 
    {
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
