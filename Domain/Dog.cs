using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public enum Sex { male, female };
    public class Dog:BaseEntity
    {
       
        public Sex DogSex { get; set; }
        public string Name { get; set; }
        public string DogDescription { get; set; }
        public string Chip { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Accepted { get; set; }
        public bool Castration { get; set; }
        public bool ChronicDisease { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int RaceId { get; set; }
        public Race Race { get; set; }
        public ICollection<HealthCard> HealthCards { get; set; }
        public ICollection<Toy> Toys { get; set; }
        public ICollection<DogEducator> DogEducators { get; set; }
        public ICollection<DogService> DogServices { get; set; }
        public ICollection<MedicalReport> DogMedicalReports { get; set; }
        public ICollection<DogHeat> DogHeats { get; set; }
        public ICollection<ChronicDisease> ChronicDiseases { get; set; }
    }
}
