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
    public class SaveClientTest
    {
        private readonly SaveClient _useCase;
        private readonly Mock<IClientGateway> _mockClientGateway;
        private readonly Mock<IBaseRepository> _mockBaseRepository;

        public SaveClientTest()
        {
            _mockClientGateway = new Mock<IClientGateway>();
            _mockBaseRepository = new Mock<IBaseRepository>();
            _useCase = new SaveClient(_mockClientGateway.Object, _mockBaseRepository.Object);
        }

        [Fact]
        public async Task ShouldSaveClient()
        {
            var request = new SaveClientDto("Bruce", "09495990696", new DateTime(1991, 05, 19), "3256855")
            {
                Address = new SaveOrUpdateAddressDto("Vinte e um", "8", "Capelinha", "Casa", "32678274", 1)
            };

            _mockClientGateway.Setup(f => f.SaveClient(It.IsAny<Client>())).ReturnsAsync(true);

            var result = await _useCase.Execute(request);

            result.Should().BeTrue();

            _mockClientGateway.Verify(f => f.SaveClient(It.IsAny<Client>()), Times.Once());
        }

        [Fact]
        public async Task ShouldntSaveClient()
        {
            var request = new SaveClientDto("Bruce", "09495990696", new DateTime(1991, 05, 19), "3256855")
            {
                Address = new SaveOrUpdateAddressDto("Vinte e um", "8", "Capelinha", "Casa", "32678274", 1)
            };

            _mockClientGateway.Setup(f => f.SaveClient(It.IsAny<Client>())).ReturnsAsync(false);

            var result = await _useCase.Execute(request);

            result.Should().BeFalse();

            _mockClientGateway.Verify(f => f.SaveClient(It.IsAny<Client>()), Times.Once());
        }
    }
}
