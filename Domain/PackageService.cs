using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PackageService
    {
        public int ServiceId { get; set; }
        public int PackageId { get; set; }
        public Service Service { get; set; }
        public Service Package { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
