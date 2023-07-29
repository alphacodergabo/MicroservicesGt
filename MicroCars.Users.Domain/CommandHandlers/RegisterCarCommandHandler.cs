using MediatR;
using MicroCars.Domain.Core.Bus;
using MicroCars.Users.Domain.Commands;
using MicroCars.Users.Domain.Events;

namespace MicroCars.Users.Domain.CommandHandlers
{
    public class RegisterCarCommandHandler : IRequestHandler<CreateRegisterCommand, bool>
    {
        private readonly IEventBus _bus;

        public RegisterCarCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new RegisterCarCreatedEvent(request.Brand, request.Model, request.Power, request.Category, request.Color, request.DoorsPassenger, request.RegistrationPlate
                , request.Fuel, request.YearOfProduction, true, request.RegistrationUser, DateTime.Now));
            return Task.FromResult(true);
        }
    }
}
