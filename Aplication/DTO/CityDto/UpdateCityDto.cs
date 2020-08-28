using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTO.CityDto
{
    public class UpdateCityDto:BaseDto
    {
        public string CityName { get; set; }
        public int ZipCode { get; set; }
    }
}
