using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTO.UserDTO
{
    public class UpdateUserDto:BaseDto
    {
        
        public string FirstName { get; set; } 
        public string Surname { get; set; }
       
        public string Email { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PhoneNumber { get; set; }
       
    }
}
