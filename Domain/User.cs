using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    
    public class User: BaseEntity
    {
        public Sex UserSex { get; set; }
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        
        public ICollection<Dog> Dogs { get; set; }
        public Employe Employe { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Payout> Payouts { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public ICollection<DogEducator> EducatorDogs { get; set; }
        public ICollection<MedicalReport> VeterinarianMedicalReports { get; set; }
    }
}
