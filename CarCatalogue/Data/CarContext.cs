using CarCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace CarCatalogue.Data
{
    public class CarContext: DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarSpec>().HasKey(di => new
            {
                di.CarId,
                di.SpecId
            });
            modelBuilder.Entity<CarSpec>().HasOne(d => d.Spec).WithMany(di => di.CarSpecs).HasForeignKey(d => d.SpecId);
            modelBuilder.Entity<CarSpec>().HasOne(i => i.Car).WithMany(di => di.CarSpecs).HasForeignKey(i => i.CarId);

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Name = "Kasla", ImageUrl = "https://img.freepik.com/free-psd/time-machine-concept-isolated_23-2151874012.jpg?t=st=1740562863~exp=1740566463~hmac=32e8ff462d027d26353018ed39b93ef535d0f147085155321066a981486c58c5&w=1380" }
                );
            modelBuilder.Entity<Spec>().HasData(
                new Spec { Id = 1, Name = "Centralised Voice Control OS" },
                new Spec { Id = 2, Name = "Flying Amphibious" }
                );
            modelBuilder.Entity<CarSpec>().HasData(
                new CarSpec { CarId = 1, SpecId = 1 },
                new CarSpec { CarId = 1, SpecId = 2 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Spec> Specs { get; set; }
        public DbSet<CarSpec> CarSpecs { get; set; }
    }
}
