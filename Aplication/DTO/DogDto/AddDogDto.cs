using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain;


namespace Aplication.DTO.DogDto
{
    public class AddDogDto
    {
        [Required(ErrorMessage = "this field is required")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public Sex DogSex { get; set; }
        [Required]
        public string DogDescription { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Chip must have at least 8 caracters")]
        public string Chip { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public bool Castration { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RaceId { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public int CardNumer { get; set; }
        [Required]
        public int EducatorId { get; set; }
        public bool? IsMain { get; set; }
        public IEnumerable<DogDiseaseDto> DtoDogDiseases { get; set; }
    }
}
