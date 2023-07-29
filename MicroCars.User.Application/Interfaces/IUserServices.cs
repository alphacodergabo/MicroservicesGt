using MicroCars.User.Application.Models;
using MicroCars.User.Application.Models.Dto;
using MicroCars.Users.Domain.Models;

namespace MicroCars.User.Application.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<RentUsers>> UsersList();
        object Transfer(VehicleCreationTransfer vehicleCreationTransfer);
        Task<BasicResponseDto> RentVehicle(RentRegister rent);
        Task<BasicResponseDto> ReturnVehicle(int OrderId);
        Task<IEnumerable<ListVehiclesDto>> VehicleListQuery();
    }
}
