namespace MicroCars.Users.Domain.Commands
{
    public class CreateRegisterCommand : RegisterCarCommand
    {
        public CreateRegisterCommand(string brand, string model, int power, string category, string color, int doorsPassenger, string registrationPlate, string fuel, DateTime yearOfProduction, string registrationUser)
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
            RegistrationUser = registrationUser;
            RegistrationDate = DateTime.Now;
            Active = true;
        }
    }
}
