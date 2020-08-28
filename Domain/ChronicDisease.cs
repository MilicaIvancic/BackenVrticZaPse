using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ChronicDisease:BaseEntity
    {
        
        public string NameChronicDisease { get; set; }
        public ICollection<DogChronichDisease> ChronichDiseaseDogs { get; set; }

    }
}
