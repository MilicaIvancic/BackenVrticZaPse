using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class EducatorReport:BaseEntity
    {
        public int DogEducatorId { get; set; }
        public DogEducator DogEducator { get; set; }
        public string DescriptionText { get; set; }
        public DateTime StartTimePeriod { get; set; }
        public DateTime? EndTimePeriod { get; set; }
    }
}
