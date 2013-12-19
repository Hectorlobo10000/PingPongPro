using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using PingPongPro.Domain;

namespace PinPongPro.Presentation.Infrastructure
{
    public class AutoFacEventDisptacher : IEventDispatcher
    {
        readonly ILifetimeScope _lifetimeScope;

        public AutoFacEventDisptacher(ILifetimeScope lifetimeScope)
         {
             _lifetimeScope = lifetimeScope;
             
         }

        public void Raise<TEvent>(TEvent @event) where TEvent : IEvent
        {
            foreach (var o in GetProcessorToHandleCommand(@event))
            {
                o.Handle(@event);
            }
        }

        IEnumerable<dynamic> GetProcessorToHandleCommand(IEvent @event)
        {
            var typeOfService = typeof(IEventHandler<>).MakeGenericType(@event.GetType());
            var typeOfGenericCollection = typeof(IEnumerable<>).MakeGenericType(typeOfService);
            return ((IEnumerable)_lifetimeScope.Resolve(typeOfGenericCollection)).Cast<object>();
        }
    }
}