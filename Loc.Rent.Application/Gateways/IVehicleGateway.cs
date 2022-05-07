using Loc.Rent.ApplicationCore.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.Gateways
{
    public interface IVehicleGateway
    {
        Task<bool> SaveVehicle(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> FindByPlate(string plate);
        Task<IEnumerable<Vehicle>> FindAll(int modelId, int manufacturerId);
        Task<IEnumerable<string>> FindAllVehiclesWithReturnDateExpired();
        Task<bool> Exists(int id);
    }
}
