using System;

namespace PingPongPro.Domain.Events
{
    public class TournamentCreated:IEvent
    {
        public readonly Guid Id;
        public readonly string Name;

        public TournamentCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}