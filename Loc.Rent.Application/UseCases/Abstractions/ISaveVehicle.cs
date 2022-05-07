using Loc.Rent.ApplicationCore.Domains.Dto;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.UseCases.Abstractions
{
    public interface ISaveVehicle
    {
        Task<bool> Execute(SaveVehicleDto request);
    }
}
