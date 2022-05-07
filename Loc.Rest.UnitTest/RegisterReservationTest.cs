using FluentAssertions;
using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Domains.Dto;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.Gateways.Base;
using Loc.Rent.ApplicationCore.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Loc.Rest.UnitTest
{
    public class RegisterReservationTest
    {
        private readonly RegisterReservation _useCase;
        private readonly Mock<IReservationGateway> _mockReservationGateway;
        private readonly Mock<IClientGateway> _mockClientGateway;
        private readonly Mock<IVehicleGateway> _mockVehicleGateway;
        private readonly Mock<IBaseRepository> _mockBaseRepository;

        public RegisterReservationTest()
        {
            _mockReservationGateway = new Mock<IReservationGateway>();
            _mockClientGateway = new Mock<IClientGateway>();
            _mockVehicleGateway = new Mock<IVehicleGateway>();
            _mockBaseRepository = new Mock<IBaseRepository>();            
            _useCase = new RegisterReservation(_mockReservationGateway.Object, _mockBaseRepository.Object, _mockVehicleGateway.Object, _mockClientGateway.Object);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ShouldRegisterReservation(bool assert)
        {
            var request = CreateRegisterReservationDto();


            _mockBaseRepository.Setup(f => f.FindAllAsync(It.IsAny<Expression<Func<Reservation, bool>>>())).ReturnsAsync(new List<Reservation>());
            _mockClientGateway.Setup(f => f.Exists(It.IsAny<int>())).ReturnsAsync(true);
            _mockVehicleGateway.Setup(f => f.Exists(It.IsAny<int>())).ReturnsAsync(true);
            _mockReservationGateway.Setup(f => f.RegisterReservation(It.IsAny<Reservation>())).ReturnsAsync(assert);

            var result = await _useCase.Execute(request);

            result.Should().Be(assert);

            _mockReservationGateway.Verify(f => f.RegisterReservation(It.IsAny<Reservation>()), Times.Once());
        }

        private RegisterReservationDto CreateRegisterReservationDto()
        {
            return new RegisterReservationDto(1, 1, true, DateTime.Now.AddDays(7));
        }
    }
}
