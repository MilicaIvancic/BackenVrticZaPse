using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DTO.DogDto;
using Domain;
using Microsoft.AspNetCore.Http;

namespace API.ApiTransverData
{
    public class AddDogApi
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

        public string Email { get; set; } = "milica.zajeganovic.ivancic@gmail.com";

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public bool Castration { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RaceId { get; set; }
        [Required]
        public IFormFile Img { get; set; }

        [Required]
    
        public int CardNumer { get; set; }
        [Required]
        public int EducatorId { get; set; }
        public bool? IsMain { get; set; }
        public IEnumerable<DogDiseaseDto> DtoDogDiseases { get; set; }
    }
}
