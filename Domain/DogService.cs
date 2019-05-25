using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DogService:BaseEntity
    {
        public int DogId { get; set; }
        public int ServiceId { get; set; }
        public Dog Dog { get; set; }
        public Service Service { get; set; }
        public DateTime? EndAt { get; set; }

    }
}
