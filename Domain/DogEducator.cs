using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DogEducator
    {
        public bool IsMain { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int EducatorId { get; set; }
        public int DogId { get; set; }
        public Employe Employe { get; set; }
        public Dog Dog { get; set; }

    }
}
