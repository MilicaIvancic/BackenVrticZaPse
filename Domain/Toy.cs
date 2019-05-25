using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Toy:BaseEntity
    {
        public string ToyName { get; set; }
        public string ToyDescription { get; set; }
        public int DogId { get; set; }
        public Dog Dog { get; set; }
    }
}
