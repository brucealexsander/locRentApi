using FluentAssertions;
using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.UseCases;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Loc.Rest.UnitTest
{
    public class UpdateReservationTest
    {
        private readonly UpdateReservation _useCase;
        private readonly Mock<IReservationGateway> _mockReservationGateway;

        public UpdateReservationTest()
        {
            _mockReservationGateway = new Mock<IReservationGateway>();
            _useCase = new UpdateReservation(_mockReservationGateway.Object);
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ShoulUpdateReservation(bool assert)
        {
            _mockReservationGateway.Setup(f => f.FindById(1)).ReturnsAsync(new Reservation(1));
            _mockReservationGateway.Setup(f => f.UpdateReservation(It.IsAny<Reservation>())).ReturnsAsync(assert);

            var result = await _useCase.Execute(1, DateTime.Now);

            result.Should().Be(assert);

            _mockReservationGateway.Verify(f => f.UpdateReservation(It.IsAny<Reservation>()), Times.Once());
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ShoulUpdateReservationDenovo(bool assert)
        {
            _mockReservationGateway.Setup(f => f.FindById(1)).ReturnsAsync(new Reservation(1));
            _mockReservationGateway.Setup(f => f.UpdateReservation(It.IsAny<Reservation>())).ReturnsAsync(assert);

            var result = await _useCase.Execute(1, DateTime.Now, DateTime.Now.AddDays(9));

            result.Should().Be(assert);

            _mockReservationGateway.Verify(f => f.UpdateReservation(It.IsAny<Reservation>()), Times.Once());
        }
    }
}
