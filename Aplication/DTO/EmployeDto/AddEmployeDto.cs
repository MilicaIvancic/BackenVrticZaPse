using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain;

namespace Aplication.DTO.EmployeDto
{
    public class AddEmployeDto
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
        public int RoleId { get; set; }
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
        [Required]
        public string Description { get; set; }
        [Required]
        public string LastFinishedEducation{ get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Alt { get; set; }
    }
}
