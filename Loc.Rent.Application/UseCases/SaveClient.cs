using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Domains.Dto;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.Gateways.Base;
using Loc.Rent.ApplicationCore.UseCases.Abstractions;
using System;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.UseCases
{
    public class SaveClient : ISaveClient
    {
        private readonly IClientGateway _clientGateway;
        private readonly IBaseRepository _baseRepository;

        public SaveClient(IClientGateway clientGateway, IBaseRepository baseRepository)
        {
            _clientGateway = clientGateway;
            _baseRepository = baseRepository;
        }

        public async Task<bool> Execute(SaveClientDto request)
        {

            var clientExists = await _baseRepository.FindAsync<Client>(c=> c.Cpf == request.Cpf);

            if (clientExists != null)
            {
                throw new Exception("There is already a client with this cpf");
            }

            var client = new Client
            {
                Name = request.Name,
                Cpf = request.Cpf,
                BirthdayDate = request.BirthdayDate,
                DriverLicense = request.DriverLicense
            };

            BuildAddress(client, request);

            return await _clientGateway.SaveClient(client);
        }

        private void BuildAddress(Client client, SaveClientDto request)
        {
            client.Address = new Address
            {
                Street = request.Address.Street,
                Number = request.Address.Number,
                Neighborhood = request.Address.Neighborhood,
                Complement = request.Address.Complement,
                ZipCode = request.Address.ZipCode,
                Client = client,
                City = new City(request.Address.CityId)
            };
        }
    }
}


