using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace Aplication.DTO.UserDTO
{
    public class GetUsersDto:BaseDto
    {
        [Required(ErrorMessage = "this field is required")]
        //[RegularExpression("/^(male|female)$/")]
        public Sex UserSex { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [MinLength(3, ErrorMessage = "Firsr Name must have at least 3 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [MinLength(3, ErrorMessage = "Last Name name must have at least 3 characters.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Timestamp]
        public DateTime BirthDate { get; set; }
        public IEnumerable<string> DogNames { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string RoleName { get; set; }
        
    }
}
