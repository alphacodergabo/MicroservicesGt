using MicroCars.Cars.Application.Interfaces;
using MicroCars.Cars.Domain.Interfaces;
using MicroCars.Cars.Domain.Models;
using MicroCars.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.Cars.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IEventBus _bus;

        public CarService(ICarRepository carRepository, IEventBus bus)
        {
            _carRepository = carRepository;
            _bus = bus;
        }

        public Task<IEnumerable<CarsRent>> ListCards()
        {
            return _carRepository.ListCards();
        }
    }
}
