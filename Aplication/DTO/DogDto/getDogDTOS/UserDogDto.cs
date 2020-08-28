using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTO.DogDto.getDogDTOS
{
    public class UserDogDto
    {
        public string DogName { get; set; }
        public string OvnerName { get; set; }
        public string EducatorName { get; set; }
        public string PackageName { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime Today { get; set; }
        public int DogId { get; set; }
        public string DogDescription { get; set; }
        public string Race { get; set; }
        public string Chip { get; set; }
        public string Img { get; set; }
        public int heltCardId { get; set; }
        public IEnumerable<GetDogVakcine> Vakcine { get; set; }
    }
}
