using MicroCars.Cars.Domain.Events;
using MicroCars.Cars.Domain.Interfaces;
using MicroCars.Cars.Domain.Models;
using MicroCars.Domain.Core.Bus;

namespace MicroCars.Cars.Domain.EventHandlers
{
    public class CarEventHandler : IEventHandler<RegisterCarCreatedEvent>
    {
        private readonly ICarRepository _carRepository;

        public CarEventHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public Task<int> Handle(RegisterCarCreatedEvent @event)
        {
            var transaction = new CarsRent
            {
                Active = @event.Active,
                Brand = @event.Brand,
                Category = @event.Category,
                Color = @event.Color,
                DoorsPassenger = @event.DoorsPassenger,
                Fuel = @event.Fuel,
                RegistrationDate = @event.RegistrationDate,
                Model = @event.Model,
                Power = @event.Power,
                RegistrationPlate = @event.RegistrationPlate,
                RegistrationUser = @event.RegistrationUser,
                YearOfProduction = @event.YearOfProduction
            };
            var result = _carRepository.RegisterCar(transaction);
            return Task.FromResult(result);
        }
    }
}
