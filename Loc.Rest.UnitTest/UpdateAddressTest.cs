using FluentAssertions;
using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Domains.Dto;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.Gateways.Base;
using Loc.Rent.ApplicationCore.UseCases;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Loc.Rest.UnitTest
{
    public class UpdateAddressTest
    {
        public readonly UpdateAddress _useCase;
        public readonly Mock<IClientGateway> _mockClientGateway;
        private readonly Mock<IBaseRepository> _mockBaseRepository;
        

        public UpdateAddressTest()
        {
            _mockClientGateway = new Mock<IClientGateway>();
            _mockBaseRepository = new Mock<IBaseRepository>();
            _useCase = new UpdateAddress(_mockClientGateway.Object, _mockBaseRepository.Object);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ShouldUpdateAddress(bool assert)
        {
            var request = SaveOrUpdateAddressDto();

            _mockClientGateway.Setup(f => f.Find(1)).ReturnsAsync(new Client(1) {Address = new Address(1)});
            _mockClientGateway.Setup(f => f.SaveClient(It.IsAny<Client>())).ReturnsAsync(assert);

            var result = await _useCase.Execute(request);

            result.Should().Be(assert);

            _mockClientGateway.Verify(f => f.SaveClient(It.IsAny<Client>()), Times.Once());
        }

        private SaveOrUpdateAddressDto SaveOrUpdateAddressDto()
        {
            return new SaveOrUpdateAddressDto(1, "Rua 21", "8", "Capelinha", "Casa", "32654841", 1, 1);
        }
    }
}
