﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ChronicDisease:BaseEntity
    {
        public int DogId { get; set; }
        public Dog Dog { get; set; }
        public string NameChronicDisease { get; set; }
        public string Therapy { get; set; }

    }
}
