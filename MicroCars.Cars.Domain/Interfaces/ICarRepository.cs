using MicroCars.Cars.Domain.Models;

namespace MicroCars.Cars.Domain.Interfaces
{
    public interface ICarRepository
    {
        int RegisterCar(CarsRent carsRent);
        Task<IEnumerable<CarsRent>> ListCards();
    }
}
