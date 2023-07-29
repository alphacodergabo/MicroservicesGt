using MicroCars.Domain.Core.Events;

namespace MicroCars.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task<int> Handle(TEvent @event);
    }
    public interface IEventHandler { }
}
