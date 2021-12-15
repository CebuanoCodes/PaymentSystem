using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PaymentSystem.Controllers;
using PaymentSystem.Models;
using PaymentSystem.Repositories;
using System.Collections.Generic;
using Xunit;

namespace PaymentSystemTests
{
    public class PaymentTests
    {
        //private readonly ILogger<UserController> _logger;
        private readonly Mock<IDataRepository> service;
        public PaymentTests()
        {
            service = new Mock<IDataRepository>();
        }

        [Fact]
        public void GetUserById_UserObject_UserwithSpecificeIdExists()
        {
            //arrange
            var users = GetSampleUser();
            var firstUser = users[0];
            service.Setup(x => x.Get(1))
                .Returns(firstUser);
            var controller = new UserController(service.Object);

            //act
            var actionResult = controller.Get(1);
            var result = actionResult.Result as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(result);

            result.Value.Should().BeEquivalentTo(firstUser);
        }

        [Fact]
        public void GetUserById_shouldReturnBadRequest_UserWithIDNotExists()
        {
            //arrange
            var users = GetSampleUser();
            var firstUser = users[0];
            service.Setup(x => x.Get(1))
                .Returns(firstUser);
            
            var controller = new UserController(service.Object);

            //act
            var actionResult = controller.Get(2);

            //assert
            var result = actionResult.Result;
            Assert.IsType<NotFoundObjectResult>(result);
        }


        private List<User> GetSampleUser()
        {
            List<User> user = new List<User>
            {
                new User
                {
                    Id = 1,
                    AccountBalance = 650000

                },
                new User
                {
                    Id =2,
                    AccountBalance = 780000
                  },

                new User
                {
                    Id = 3,
                    AccountBalance = 980000

                }
        };
            return user;
        }
    }
}