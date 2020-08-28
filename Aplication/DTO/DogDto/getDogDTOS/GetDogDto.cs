using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Paginate;

namespace Aplication.DTO.DogDto.getDogDTOS
{
    public class GetDogDto:BaseDto
    {
        public string DogName { get; set; }
        public string OvnerName { get; set; }
        public string EducatorName { get; set; }
        public string DogDescription { get; set; }
        public string Race { get; set; }
        public string Chip { get; set; }
        public IEnumerable<GetDogVakcine> Vakcine { get; set; }
        public IEnumerable<GetDogZIvestaj> VeterinarskiIzvestaj { get; set; }
        
        public IEnumerable<GetDogMedicinskiIZvestaj> MedicinskiIzvestaj { get; set; }
        public IEnumerable<GetDogHroncineBolesti> HronicneBolesti { get; set; }
    }
}
