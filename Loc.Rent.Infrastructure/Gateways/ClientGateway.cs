using LinqKit;
using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Domains.Dto;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.Gateways.Base;
using Loc.Rent.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Loc.Rent.Infrastructure.Gateways
{
    public class ClientGateway : IClientGateway
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IClientRepository _clientRepository;

        public ClientGateway(IBaseRepository baseRepository, IClientRepository clientRepository)
        {
            _baseRepository = baseRepository;
            _clientRepository = clientRepository;
        }

        public Task<Client> Find(int id) 
        {
            return _baseRepository.FindByIdAsync<Client>(id);
        }

        public async Task<IEnumerable<Client>> FindAll(FindAllClientDto clientDto)
        {
            Expression<Func<Client, bool>> expression = PredicateBuilder.New<Client>(r => true);

            if (!string.IsNullOrEmpty(clientDto.Cpf))
                expression = expression.And(c => c.Cpf.Replace(".", "").Replace("-", "") == clientDto.Cpf.Replace(".", "").Replace("-", ""));

            if (!string.IsNullOrEmpty(clientDto.Name))
                expression = expression.And(c => c.Name.Contains(clientDto.Name));

            return await _baseRepository.FindAllAsync(expression);
        }

        public Task<bool> SaveClient(Client client)
        {
            return _baseRepository.SaveOrUpdate(client);
        }

        public Task<bool> Exists(int id)
        {
            return _clientRepository.Exists(id);
        }
    }
}
