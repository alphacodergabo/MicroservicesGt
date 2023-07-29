using MicroCars.Cars.Application.Interfaces;
using MicroCars.Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroCars.Cars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsRentController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsRentController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("GetCarsList")]
        public async Task<IEnumerable<CarsRent>> GetCarsList()
        {
            try
            {
                return await _carService.ListCards();
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }

        }
    }
}
