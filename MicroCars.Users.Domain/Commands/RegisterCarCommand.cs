using MicroCars.Domain.Core.Commands;

namespace MicroCars.Users.Domain.Commands
{
    public abstract class RegisterCarCommand : Command
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public int DoorsPassenger { get; set; }
        public string RegistrationPlate { get; set; }
        public string Fuel { get; set; }
        public DateTime YearOfProduction { get; set; }
        public bool Active { get; set; }
        public string RegistrationUser { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
