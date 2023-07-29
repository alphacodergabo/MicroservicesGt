using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.User.Application.Models
{
    public class RentRegister
    {
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public DateTime RentDate { get; set; }
    }
}
