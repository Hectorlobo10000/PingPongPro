namespace PingPongPro.Domain
{
    public interface IEventDispatcher
    {
        void Raise<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}