using MicroCars.Cars.Data.Context;
using MicroCars.Cars.Domain.Interfaces;
using MicroCars.Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroCars.Cars.Data.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _context;

        public CarRepository(CarDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarsRent>> ListCards()
        {
            var result = await _context.CarsRent.ToListAsync();
            var final = result.Where(x => ((int)(DateTime.Now.Date - x.YearOfProduction.Date).TotalDays < 1825));
            return final;
        }

        public int RegisterCar(CarsRent carsRent)
        {
            _context.CarsRent.Add(carsRent);
            var x = _context.SaveChanges();
            if(x > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
