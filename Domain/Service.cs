using System.Collections.Generic;

namespace Domain
{
    public class Service:BaseEntity
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public bool IsPackage { get; set; }
        public ICollection<PriceService> PriceServices { get; set; }
        public ICollection<PackageService> PackageServices { get; set; }
        public ICollection<PackageService> ServicePackages { get; set; }
        public ICollection<DogService> ServiceDogs { get; set; }
        
    }
}
