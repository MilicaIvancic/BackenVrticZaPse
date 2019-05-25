using Domain;
using EfDataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess
{
    public class VrticZaPseContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogEducator> DogEducators { get; set; }
        public DbSet<ChronicDisease> ChronicDiseases { get; set; }
        public DbSet<DogHeat> DogHeats { get; set; }
        public DbSet<DogService> DogServices { get; set; }
        public DbSet<DogEducator> Educators { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<EmployeCertificate> EmployeCertificates { get; set; }
        public DbSet<HealthCard> HealthCards { get; set; }
        public DbSet<HealthCardVaccine> HealthCardVaccines { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineMedicalReport> MedicineMedicalReports { get; set; }
        public DbSet<PackageService> PackageServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Payout> Payouts { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PriceService> PriceServices { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=VrticZaPse;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CertificateConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new DogConfiguration());
            modelBuilder.ApplyConfiguration(new ChronicDiseaseConfiguration());
            modelBuilder.ApplyConfiguration(new DogEducatorConfiguration());
            modelBuilder.ApplyConfiguration(new DogHeatConfiguration());
            modelBuilder.ApplyConfiguration(new DogServiceConfiguration());
            modelBuilder.ApplyConfiguration(new EducatorReportConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeCertificateConfiguration());
            modelBuilder.ApplyConfiguration(new HelthCardConfiguration());
            ///proveriti ovu konfiguraciju
            modelBuilder.ApplyConfiguration(new HealthCardVaccineConfiguration());
            ///proveriti ovu konfiguraciju
            modelBuilder.ApplyConfiguration(new MedicalReportConfiguration());
            modelBuilder.ApplyConfiguration(new MedicineConfiguration());
            modelBuilder.ApplyConfiguration(new MedicineMedicalReportConfiguration());
            // proveri
            modelBuilder.ApplyConfiguration(new PackageServiceConfiguration());
            // proveriti!!!
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new PayoutConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
            modelBuilder.ApplyConfiguration(new PriceServiceConfiguration());
            modelBuilder.ApplyConfiguration(new RaceConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ToyConfiguration());
            modelBuilder.ApplyConfiguration(new VaccineConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntity item)
                {
                    if (entry.State == EntityState.Added)
                    {
                        item.CreatedAt = DateTime.Now;
                    }
                }
            }

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntity item)
                {
                    if (entry.State == EntityState.Modified)
                    {
                        item.ModifiedAt = DateTime.Now;
                    }
                }
            }


            return base.SaveChanges();
        }
    }
}
