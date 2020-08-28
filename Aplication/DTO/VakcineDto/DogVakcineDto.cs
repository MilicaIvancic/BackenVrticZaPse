using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTO.VakcineDto
{
    public class DogVakcineDto: BaseDto
    {
        public int HeltCardId { get; set; }
        public int VaccineId { get; set; }
        public DateTime ReciveAt { get; set; }
    }
}
