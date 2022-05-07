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
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Loc.Rest.UnitTest
{
    public class SaveVehicleTest
    {
        private readonly SaveVehicle _useCase;
        private readonly Mock<IVehicleGateway> _mockVehicleGateway;        

        public SaveVehicleTest()
        {
            _mockVehicleGateway = new Mock<IVehicleGateway>();            
            _useCase = new SaveVehicle(_mockVehicleGateway.Object);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ShouldSaveVehicle(bool assert)
        {
            var request = CreateSaveVehicleDto();

            _mockVehicleGateway.Setup(f => f.SaveVehicle(It.IsAny<Vehicle>())).ReturnsAsync(assert);

            var result = await _useCase.Execute(request);

            result.Should().Be(assert);

            _mockVehicleGateway.Verify(f => f.SaveVehicle(It.IsAny<Vehicle>()), Times.Once());
        }

        private SaveVehicleDto CreateSaveVehicleDto()
        {
            return new SaveVehicleDto("HPS5645", "Fiat Palio", 2013, 2013, 1);
        }
    }
}
