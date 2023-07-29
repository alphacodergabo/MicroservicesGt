using MicroCars.User.Application.Interfaces;
using MicroCars.User.Application.Models;
using MicroCars.User.Application.Models.Dto;
using MicroCars.Users.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroCars.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRentController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserRentController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet("GetUserList")]
        public async Task<IEnumerable<RentUsers>> GetUserList()
        {
            try
            {
                return await _userServices.UsersList();
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
            
        }
        [HttpPost("SaveNewVehicle")]
        public ActionResult<BasicResponseDto> Post([FromBody] VehicleCreationTransfer vehicleCreationTransfer)
        {
            var response = new BasicResponseDto();
            try
            {
                response.Status = true;
                response.Msg = "Se Registro de manera correcta";
                var y = _userServices.Transfer(vehicleCreationTransfer);
                bool flag = Convert.ToBoolean(y);
                if (!flag)
                {
                    response.Status = false;
                    response.Msg = "No se pudo registrar el vehículo";
                }
                return Ok(response);
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
            
        }
        [HttpPost("SaveNewRentRequest")]
        public ActionResult<BasicResponseDto> SaveNewRentRequest([FromBody] RentRegister rentRegister)
        {
            try
            {
                var y = _userServices.RentVehicle(rentRegister);
                return Ok(y);
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }

        }
        [HttpGet("GetCarsForRentList")]
        public async Task<IEnumerable<ListVehiclesDto>> GetCarsForRentList()
        {
            try
            {
                return await _userServices.VehicleListQuery();
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }

        }

        [HttpGet("ReturnCar/{id}", Name = "ReturnCar")]
        public async Task<BasicResponseDto> ReturnCar(int id)
        {
            try
            {
                return await _userServices.ReturnVehicle(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }

        }
    }
}
