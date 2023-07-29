using MicroCars.Users.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroCar.User.Data.Context
{
    public class RentUsersDbContext : DbContext
    {
        public RentUsersDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<RentUsers> RentUsers { get; set; }
        public DbSet<RentVehicle> RentVehicles { get; set; }
        public DbSet<ReturnVehicleLog> ReturnVehicleLogs { get; set; }
    }
}
