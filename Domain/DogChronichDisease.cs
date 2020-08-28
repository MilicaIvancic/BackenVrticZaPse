using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DogChronichDisease
    {
        public Dog Dog { get; set; }
        public int DogId { get; set; }
        public ChronicDisease ChronicDisease { get; set; }
        public int ChronicDiseaseId { get; set; }

        public string Therapy { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
