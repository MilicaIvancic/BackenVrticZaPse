using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTO.DogDto.getDogDTOS
{
    public class GetDogMedicinskiIZvestaj
    {
        public DateTime DatumKreiranja { get; set; }
        public string Opis { get; set; }
        public string Veterinar { get; set; }
        public string DogName { get; set; }
        
        public IEnumerable<DogTerapija> Terapija { get; set; }
    }
}
