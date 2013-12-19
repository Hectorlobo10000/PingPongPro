using System;

namespace PingPongPro.Domain
{
    public interface IEventHandler<in TEvent> where TEvent:IEvent
    {
        void Handle(TEvent @event);
    }
}