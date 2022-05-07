using LinqKit;
using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Loc.Rent.Infrastructure.Gateways
{
    public class VehicleGateway : IVehicleGateway
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleGateway(IVehicleRepository vehicleRepository) => _vehicleRepository = vehicleRepository;

        public Task<bool> SaveVehicle(Vehicle vehicle)
        {
            return _vehicleRepository.SaveOrUpdate(vehicle);
        }

        public async Task<IEnumerable<Vehicle>> FindByPlate(string plate)
        {
            Expression<Func<Vehicle, bool>> filter = null;

            if (!string.IsNullOrEmpty(plate))
                filter = v => v.Plate.Contains(plate);

            return await _vehicleRepository.FindAllAsync(filter);
        }

        public async Task<IEnumerable<Vehicle>> FindAll(int modelId, int manufacturerId)
        {
            Expression<Func<Vehicle, bool>> expression = PredicateBuilder.New<Vehicle>(r => true);

            if (modelId > default(int))
                expression = expression.And(v => v.Model.Id == modelId);

            if (manufacturerId > default(int))
                expression = expression.And(v => v.Model.Manufacturer.Id == manufacturerId);

            return await _vehicleRepository.FindAllAsync(expression);
        }

        public async Task<IEnumerable<string>> FindAllVehiclesWithReturnDateExpired()
        {
           return await _vehicleRepository.FindAllVehiclesWithReturnDateExpired();
        }

        public Task<bool> Exists(int id)
        {
            return _vehicleRepository.Exists(id);
        }
    }
}
