using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.User.Application.Models.Dto
{
    public class ListVehiclesDto
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Power { get; set; }
        public string? Category { get; set; }
        public string? Color { get; set; }
        public int DoorsPassenger { get; set; }
        public string? RegistrationPlate { get; set; }
        public string? Fuel { get; set; }
        public DateTime YearOfProduction { get; set; }
    }
}
