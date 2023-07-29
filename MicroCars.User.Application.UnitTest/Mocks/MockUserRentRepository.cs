using AutoFixture;
using MicroCars.Users.Domain.Interfaces;
using MicroCars.Users.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.User.Application.UnitTest.Mocks
{
    public class MockUserRentRepository
    {
        public static Mock<IUserRentRepository> ReturnVehicle()
        { 
            var fixture = new Fixture();
            var mockRepository = new Mock<IUserRentRepository>();
            mockRepository.Setup(p => p.ReturnVehicle(It.IsAny<int>()));
            return mockRepository;
        }
    }
}
