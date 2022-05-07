using Loc.Rent.ApplicationCore.Gateways.Base;
using System.Threading.Tasks;

namespace Loc.Rent.Infrastructure.Repositories
{
    public interface IClientRepository : IBaseRepository
    {
        Task<bool> Exists(int id);
    }
}
