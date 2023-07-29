using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.Users.Domain.Commands
{
    public class CreateRentCommand : RentCommand
    {
        public CreateRentCommand(int vehicleId, int userId, DateTime rentDate)
        {
            VehicleId = vehicleId;
            UserId = userId;
            RentDate = rentDate;
            RentStatus = true;
        }
    }
}
