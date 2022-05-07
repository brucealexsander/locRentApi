using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Domains.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.Gateways
{
    public interface IClientGateway
    {
        Task<bool> SaveClient(Client client);
        Task<IEnumerable<Client>> FindAll(FindAllClientDto clientDto);
        Task<Client> Find(int id);
        Task<bool> Exists(int id);
    }
}
