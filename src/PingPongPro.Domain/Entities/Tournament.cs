using System;

namespace PingPongPro.Domain.Entities
{
    public class Tournament : IEntity
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Address { get; protected set; }
        public virtual DateTime Date { get; protected set; }
        public virtual double Price { get; protected set; }

        protected Tournament()
        {
            
        }
        public Tournament(Guid id, string name, string address, DateTime date, double price)
        {
            Id = id;
            Name = name;
            Address = address;
            Date = date;
            Price = price;
        }
    }
}