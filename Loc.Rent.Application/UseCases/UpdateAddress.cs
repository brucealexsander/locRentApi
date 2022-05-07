using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Domains.Dto;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.Gateways.Base;
using Loc.Rent.ApplicationCore.UseCases.Abstractions;
using System;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.UseCases
{
    public class UpdateAddress : IUpdateAddress
    {
        private readonly IClientGateway _clientGateway;
        private readonly IBaseRepository _baseRepository;

        public UpdateAddress(IClientGateway clientGateway, IBaseRepository baseRepository) 
        { 
            _clientGateway = clientGateway;
            _baseRepository = baseRepository;
        }

        public async Task<bool> Execute(SaveOrUpdateAddressDto request)
        {
            var client = await _clientGateway.Find(request.ClientId);

            if (client == null)
            {
                throw new Exception("Client not found");
            }

            client.Address = request.Id != null ? client.Address : new Address();

            client.Address.Street = request.Street;
            client.Address.Number = request.Number;
            client.Address.ZipCode = request.ZipCode;
            client.Address.Complement = request.Complement;
            client.Address.City = new City(request.CityId);

            return await _clientGateway.SaveClient(client);
        }
    }
}
