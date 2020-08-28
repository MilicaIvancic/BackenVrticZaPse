using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.DTO.CityDto
{
    public class CityDto:BaseDto
    {
        [Required(ErrorMessage = "this field is required")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public int ZipCode { get; set; }
    }
}
