using MicroCars.Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroCars.Cars.Data.Context
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
        }
        public DbSet<CarsRent> CarsRent { get; set; }
    }
}
