using Microsoft.EntityFrameworkCore;
using CaravanMVC.Models;

namespace CaravanMVC.DataAccess
{
    public class CaravanMvcContext : DbContext
    {
        public DbSet<Wagon> Wagons { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public CaravanMvcContext(DbContextOptions<CaravanMvcContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wagon>().HasData(
                new Wagon { Id = 1, Name = "old faithful", NumWheels = 4, Covered = true },
                new Wagon { Id = 2, Name = "unreliable", NumWheels = 3, Covered = false }
            );
            modelBuilder.Entity<Passenger>().HasData(
                new Passenger { Id = 1, Name = "john doe", Age = 20, Destination = "new york", WagonId = 1},
                new Passenger { Id = 2, Name = "pam beasely", Age = 20, Destination = "new york", WagonId = 1 },
                new Passenger { Id = 3, Name = "jim halpert", Age = 20, Destination = "new york", WagonId = 1 },
                new Passenger { Id = 4, Name = "ryan howard", Age = 20, Destination = "new york", WagonId = 2 },
                new Passenger { Id = 5, Name = "michael scott", Age = 20, Destination = "new york", WagonId = 2 },
                new Passenger { Id = 6, Name = "dwight schrute", Age = 20, Destination = "new york", WagonId = 2 }
            );
        }
    }
}