using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Employe:BaseEntity
    {
        public string Description { get; set; }
        public string LastFinishedEducation { get; set; }
        public string Image { get; set; }
        public string Alt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<EmployeCertificate> EmployeCertificates { get; set; }
        public ICollection<DogEducator> EducatorDogs { get; set; }
        
    }

}
