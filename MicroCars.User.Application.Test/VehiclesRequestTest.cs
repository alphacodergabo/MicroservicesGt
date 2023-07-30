using GenFu;
using MicroCars.Domain.Core.Bus;
using MicroCars.User.Application.Interfaces;
using MicroCars.User.Application.Models.Dto;
using MicroCars.User.Application.Services;
using MicroCars.Users.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Xunit;

namespace MicroCars.User.Application.Test
{
    public class VehiclesRequestTest
    {
        // Unitario sin dependencias
        
        [Fact]
        public void GetVehiclesAsyncTest()
        {
            System.Diagnostics.Debugger.Launch();
            var mockUserRepository = new Mock<IUserServices>();
            mockUserRepository.Setup(x => x.VehicleListQuery()).CallBase();
            mockUserRepository.Verify();
            Assert.NotNull(mockUserRepository);
            
        }

        // Este test se ejecutaría sobre una uri desplegada
        //Infraestructura
        [Fact]
        public async void CallMicroService()
        {
            System.Diagnostics.Debugger.Launch();
            //Api A llamar (El servicio tendría que estar desplegado porque el test está desligado de la solución)
            string uriToTest = "http://localhost:5105/api/CarsRent/GetCarsList";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(uriToTest);
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            //Parseo de la respuesta al tipo de dto que se necesita mostrar
            var result = JsonSerializer.Deserialize<IEnumerable<ListVehiclesDto>>(content, options);

           //Verificación si el parseo tiene relacón con la entidad de salida
           Assert.IsType<ListVehiclesDto>(result);
           //Verificación si la llamada a la microservice devuelve un true.
           Assert.True(response.IsSuccessStatusCode);
        }
    }
}
