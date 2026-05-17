using InClassAssignMent.Models;
using InClassAssignMent.Models.ServiceType;
using InClassAssignMent.Models.Customars;
using InClassAssignMent.Models.Vehicles;
using InClassAssignMent.Models.VehicleServiceType;
using Microsoft.EntityFrameworkCore;

namespace InClassAssignMent.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customar> Customars { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<VehicleServiceType> VehicleServiceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Many-to-Many relationships and Seed Data

            modelBuilder.Entity<VehicleServiceType>()
                .HasKey(vst => vst.Id);

            modelBuilder.Entity<VehicleServiceType>()
                .HasOne(vst => vst.Vehicle)
                .WithMany(v => v.VehicleServiceTypes)
                .HasForeignKey(vst => vst.VehicleId);

            modelBuilder.Entity<VehicleServiceType>()
                .HasOne(vst => vst.ServiceType)
                .WithMany(st => st.VehicleServiceTypes)
                .HasForeignKey(vst => vst.ServiceTypeId);

            // Seed Data
            modelBuilder.Entity<Customar>().HasData(
                new Customar { Id = 1, Name = "Muscab axmed", Email = "Muscabqaarey@gmail.com", Phone = "+252614463895" },
                new Customar { Id = 2, Name = "mascud axmed", Email = "mascudqaarey@gmail.com", Phone = "+252614479457" }
            );

            modelBuilder.Entity<Vehicles>().HasData(
                new Vehicles { Id = 1, Make = "Marcedez", Model = "Gwagon", Year = 2020, CustomarId = 1 },
                new Vehicles { Id = 2, Make = "Honda", Model = "Civic", Year = 2021, CustomarId = 2 }
            );

            modelBuilder.Entity<ServiceType>().HasData(
                new ServiceType { Id = 1, Name = "Oil Change", Description = "Change engine oil and filter", Cost = 50.00m },
                new ServiceType { Id = 2, Name = "Tire Rotation", Description = "Rotate tires", Cost = 30.00m }
            );

            modelBuilder.Entity<VehicleServiceType>().HasData(
                new VehicleServiceType { Id = 1, VehicleId = 1, ServiceTypeId = 1, ServiceDate = new DateTime(2023, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                new VehicleServiceType { Id = 2, VehicleId = 2, ServiceTypeId = 2, ServiceDate = new DateTime(2023, 10, 5, 0, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}
