using MicroCars.Users.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.Users.Domain.Interfaces
{
    public interface IUserRentRepository
    {
        Task<IEnumerable<RentUsers>> UsersList();
        Task<int> RegisterRent(RentVehicle rent);
        Task<int> ReturnVehicle(int rentOrder);
    }
}
