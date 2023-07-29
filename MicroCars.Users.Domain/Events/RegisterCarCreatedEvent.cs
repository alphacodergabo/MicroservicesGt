using MicroCars.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.Users.Domain.Events
{
    public class RegisterCarCreatedEvent : Event
    {
        public string Brand { get; protected set; }
        public string Model { get; protected set; }
        public int Power { get; protected set; }
        public string Category { get; protected set; }
        public string Color { get; protected set; }
        public int DoorsPassenger { get; protected set; }
        public string RegistrationPlate { get; protected set; }
        public string Fuel { get; protected set; }
        public DateTime YearOfProduction { get; protected set; }
        public bool Active { get; protected set; }
        public string RegistrationUser { get; protected set; }
        public DateTime RegistrationDate { get; protected set; }

        public RegisterCarCreatedEvent(string brand, string model, int power, string category, string color, int doorsPassenger, string registrationPlate, string fuel, DateTime yearOfProduction, bool active, string registrationUser, DateTime registrationDate)
        {
            Brand = brand;
            Model = model;
            Power = power;
            Category = category;
            Color = color;
            DoorsPassenger = doorsPassenger;
            RegistrationPlate = registrationPlate;
            Fuel = fuel;
            YearOfProduction = yearOfProduction;
            Active = true;
            RegistrationUser = registrationUser;
            RegistrationDate = DateTime.Now;
        }
    }
}
