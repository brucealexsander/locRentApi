using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Gateways.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loc.Rent.Infrastructure.Repositories
{
    public interface IVehicleRepository : IBaseRepository
    {
        Task<IList<string>> FindAllVehiclesWithReturnDateExpired();
        Task<bool> Exists(int id);
    }
}
