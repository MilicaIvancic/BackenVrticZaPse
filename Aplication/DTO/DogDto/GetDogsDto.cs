using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain;

namespace Aplication.DTO.DogDto
{
    public class GetDogsDto
    {
        [Required(ErrorMessage = "this field is required")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters.")]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public int EducatorId { get; set; }
        [Required]
        public int RaceId { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public string ImageName { get; set; }

        [Required]
        public string EducatorName { get; set; }
        [Required]
        public int DogId { get; set; }
        public bool IsActive { get; set; }


    }
}
