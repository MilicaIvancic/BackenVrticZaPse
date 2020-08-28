using System.ComponentModel.DataAnnotations;

namespace Aplication.DTO
{
    public class RoleDto:BaseDto
    {
        [Required(ErrorMessage = "this field is required")]
        [MinLength(4, ErrorMessage = "Category name must have at least 3 characters.")]
        public string RoleName { get; set; }
        

    }
}
