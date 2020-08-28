using System.ComponentModel.DataAnnotations;

namespace Aplication.DTO.RaceDto
{
    public class RaceDto:BaseDto
    {
        [Required]
        public string Name { get; set; }
    }
}
