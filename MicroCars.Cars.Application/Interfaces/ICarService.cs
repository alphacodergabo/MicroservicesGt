using MicroCars.Cars.Domain.Models;

namespace MicroCars.Cars.Application.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarsRent>> ListCards();
    }
}
