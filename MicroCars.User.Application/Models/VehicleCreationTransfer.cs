using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.User.Application.Models
{
    public class VehicleCreationTransfer
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
