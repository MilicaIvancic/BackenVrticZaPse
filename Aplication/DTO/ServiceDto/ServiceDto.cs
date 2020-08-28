using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTO.ServiceDto
{
    public class ServiceDto
    {
      
        public decimal Price { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
    }
}
