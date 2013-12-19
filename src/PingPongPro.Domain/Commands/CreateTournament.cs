using System;

namespace PingPongPro.Domain.Commands
{
    public class CreateTournament : ICommand
    {
        readonly string _address;
        readonly DateTime _date;
        readonly Guid _id;
        readonly string _name;
        readonly double _price;

        protected CreateTournament()
        {
            
        }

        public CreateTournament(Guid id, string name, string address, DateTime date, double price)
        {
            _id = id;
            _name = name;
            _address = address;
            _date = date;
            _price = price;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Address
        {
            get { return _address; }
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public double Price
        {
            get { return _price; }
        }
    }
}