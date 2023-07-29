using MicroCar.User.Data.Context;
using MicroCars.Users.Domain.Interfaces;
using MicroCars.Users.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MicroCar.User.Data.Repository
{
    public class UserRentRepository : IUserRentRepository
    {
        private readonly RentUsersDbContext _context;

        public UserRentRepository(RentUsersDbContext context)
        {
            _context = context;
        }

        public async Task<int> RegisterRent(RentVehicle rent)
        {
            var exist = _context.RentVehicles.Any( x => x.UserId == rent.UserId && rent.VehicleId == x.VehicleId && x.RentStatus == true);
            if (exist)
            {
                return 0;
            }
            else
            {
                await _context.RentVehicles.AddAsync(rent);
                var response = _context.SaveChanges();
                if (response > 0)
                {
                    return 1;
                }
                return 0;
            }
        }

        public async Task<int> ReturnVehicle(int rentOrder)
        {
            try
            {
                var exist = await _context.RentVehicles.FirstOrDefaultAsync(x => x.Id ==rentOrder && x.RentStatus == true);
                if (exist?.Id == rentOrder)
                {
                    exist.RentStatus = false;

                    var saveLog = new ReturnVehicleLog { OrderId = rentOrder };

                    await _context.ReturnVehicleLogs.AddAsync(saveLog);

                    var result =_context.SaveChanges();
                    if(result>0) {
                        return 1;
                    }
                    return 0;
                }
                return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
        }

        public async Task<IEnumerable<RentUsers>> UsersList()
        {
            var user = await _context.RentUsers.ToListAsync();
            return user;
        }
    }
}
