using Loc.Rent.ApplicationCore.Domains.Dto;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.UseCases.Abstractions;
using Loc.Rent.Web.Request;
using Loc.Rent.Web.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Loc.Rent.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : Controller
    {
        private readonly ISaveVehicle _saveVehicle;
        private readonly IVehicleGateway _vehicleGateway;

        public VehicleController(ISaveVehicle saveVehicle, IVehicleGateway vehicleGateway)
        {
            _saveVehicle = saveVehicle;
            _vehicleGateway = vehicleGateway;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Create([FromBody] SaveVehicleRequest request)
        {
            var vehicle = await _saveVehicle.Execute(new SaveVehicleDto
                (
                    request.Plate,
                    request.Description,
                    request.ManufactureYear,
                    request.ModelYear,
                    request.ModelId
                ));

            if (vehicle)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("find-by-plate")]
        public async Task<IEnumerable<FindVehicleByPlateResponse>> FindByPlate([FromQuery] string plate)
        {
            var vehicles = await _vehicleGateway.FindByPlate(plate);

            if (vehicles.Any())
            {
                return vehicles.Select(v => new FindVehicleByPlateResponse(v.Description, v.ManufactureYear, v.ModelYear, v.Model.Name, v.Model.Manufacturer.Name));
            }

            return new List<FindVehicleByPlateResponse>();
        }

        [HttpGet("find-all")]
        public async Task<IEnumerable<FindAllVehicleResponse>> FindAll([FromQuery] int modelId, int manufacturerId)
        {
            var vehicles = await _vehicleGateway.FindAll(modelId, manufacturerId);

            if (vehicles.Any())
            {
                return vehicles.Select(v => new FindAllVehicleResponse(v.Description, v.ManufactureYear, v.ModelYear, v.Model.Name, v.Model.Manufacturer.Name));
            }

            return new List<FindAllVehicleResponse>();
        }

        [HttpGet("find-vehicles-expired-return-date")]
        public Task<IEnumerable<string>> FindAllExpiredReturn()
        {
            return _vehicleGateway.FindAllVehiclesWithReturnDateExpired();
        }
    }
}
