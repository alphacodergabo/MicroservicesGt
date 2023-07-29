using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.Cars.Domain.Models
{
    public class CarsRent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int VehicleId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Brand { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Model { get; set; }
        public int Power { get; set; }
        [Column(TypeName = "varchar(2)")]
        public string? Category { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Color { get; set; }
        public int DoorsPassenger { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? RegistrationPlate { get; set; }
        public DateTime YearOfProduction { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Fuel { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? RegistrationUser { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
