using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain;

namespace Aplication.DTO.EmployeDto
{
    public class EmployeDto:BaseDto
    {
        public Sex UserSex { get; set; }
        public string FirstName { get; set; }
        public string Description { get; set; }
        public string LastFinishedEducation { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Image { get; set; }
        public DateTime BirthDate { get; set; }
        
    }
}
