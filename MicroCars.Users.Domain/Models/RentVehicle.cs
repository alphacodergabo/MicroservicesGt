using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.Users.Domain.Models
{
    public class RentVehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public DateTime RentDate { get; set; }
        public bool RentStatus { get; set; }
    }
}
