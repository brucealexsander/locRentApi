using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Domains.Dto;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.UseCases.Abstractions;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.UseCases
{
    public class SaveVehicle : ISaveVehicle
    {
        private readonly IVehicleGateway _vehicleGateway;        

        public SaveVehicle(IVehicleGateway vehicleGateway)
        {
            _vehicleGateway = vehicleGateway;            
        }

        public Task<bool> Execute(SaveVehicleDto request)
        {
            var vehicle = new Vehicle
            {
                Plate = request.Plate,
                Description = request.Description,
                ManufactureYear = request.ManufactureYear,
                ModelYear = request.ModelYear,
                Model = new Model(request.ModelId)
            };

            return _vehicleGateway.SaveVehicle(vehicle);
        }
    }
}
