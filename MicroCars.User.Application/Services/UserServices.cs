using MicroCars.Domain.Core.Bus;
using MicroCars.User.Application.Interfaces;
using MicroCars.User.Application.Models;
using MicroCars.User.Application.Models.Dto;
using MicroCars.Users.Domain.Commands;
using MicroCars.Users.Domain.Interfaces;
using MicroCars.Users.Domain.Models;
using System.Text.Json;

namespace MicroCars.User.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRentRepository _userRentRepository;
        private readonly IEventBus _bus;
        private readonly IHttpClientFactory _httpClient;

        public UserServices(IUserRentRepository userRentRepository, IEventBus bus, IHttpClientFactory httpClient)
        {
            _userRentRepository = userRentRepository;
            _bus = bus;
            _httpClient = httpClient;
        }

        public async Task<BasicResponseDto> RentVehicle(RentRegister rent)
        {
            try
            {
                var response = new BasicResponseDto();
                response.Status = true;
                response.Msg = "Se registró Correctamente la renta del vehículo";
                var createRentRequest = new CreateRentCommand(rent.VehicleId, rent.UserId, rent.RentDate);
                var callService = await _userRentRepository.RegisterRent(createRentRequest);
                if(callService!=1)
                {
                    response.Status = false;
                    response.Msg = "Ya tienes un vehículo rentado";
                }
                return response;
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
            
             
        }

        public async Task<BasicResponseDto> ReturnVehicle(int OrderId)
        {
            try
            {
                var response = new BasicResponseDto();
                response.Status = true;
                response.Msg = "Has devuelto el vehículo";
                var executeCommand = await _userRentRepository.ReturnVehicle(OrderId);
                if (executeCommand != 1)
                {
                    response.Status = false;
                    response.Msg = "La orden que has entregado no existe o ya ha sido entregada";
                }
                return response;
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }  
        }

        public object Transfer(VehicleCreationTransfer v)
        {
            var createRegisterCommand = new CreateRegisterCommand(v.Brand,v.Model,v.Power,v.Category,v.Color,v.DoorsPassenger,v.RegistrationPlate,v.Fuel,v.YearOfProduction,v.RegistrationUser);
            var x = _bus.SendCommand(createRegisterCommand);
            return x.IsCompletedSuccessfully;
        }

        public Task<IEnumerable<RentUsers>> UsersList()
        {
            return _userRentRepository.UsersList();
        }

        public async Task<IEnumerable<ListVehiclesDto>> VehicleListQuery()
        {
            try
            {
                var client = _httpClient.CreateClient("CarsForRent");
                var response = await client.GetAsync("api/CarsRent/GetCarsList");
                if(response.IsSuccessStatusCode) 
                { 
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<ListVehiclesDto>>(content, options);
                    return result;
                }
                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
        }
    }
}
