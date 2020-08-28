using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;

namespace API.ApiTransverData
{
   public class ApiTransfewrEmploye
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
        [Required(ErrorMessage = "this field is required")]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string StreetNumber { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Phone number must have at least 8 nubers")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string LastFinishedEducation { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public IFormFile Image { get; set; }
       
    }
}
