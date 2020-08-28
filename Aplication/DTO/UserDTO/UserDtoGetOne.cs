using System;
using System.Collections.Generic;
using Domain;

namespace Aplication.DTO.UserDTO
{
   public  class UserDtoGetOne
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Sex UserSex { get; set; }
        
        public string Email { get; set; }
       
        public DateTime BirthDate { get; set; }
       
        public string RoleName { get; set; }
        public IEnumerable<UsersDogDto> DogNames { get; set; }
        
        public string CityName { get; set; }
      
        public string Street { get; set; }
      
        public string StreetNumber { get; set; }

        public int Id { get; set; }

        public IEnumerable<string> PhoneNumbers { get; set; }

    }
}
