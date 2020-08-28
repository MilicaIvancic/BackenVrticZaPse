using System;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace Aplication.DTO.UserDTO
{
    public class UserDto:BaseDto
    {
        [Required(ErrorMessage = "this field is required")]
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
        [Required]
        public int CityId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Phone number must have at least 8 nubers")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }



    }
}
