using Loc.Rent.ApplicationCore.Domains;
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
    public class ClientController : Controller
    {
        private readonly IClientGateway _clientGateway;
        private readonly IUpdateAddress _updateAddress;
        private readonly ISaveClient _saveClient;

        public ClientController(IClientGateway clientGateway, IUpdateAddress updateAddress, ISaveClient saveClient)
        {
            _clientGateway = clientGateway;
            _updateAddress = updateAddress;
            _saveClient = saveClient;
        }

        [HttpGet]
        public async Task<IEnumerable<FindAllClienteResponse>> FindAll([FromQuery]FindAllClientRequest request)
        {
            var clients = await _clientGateway.FindAll(new FindAllClientDto(request.Cpf, request.Name));

            if (clients.Any())
            {
                return clients.Select(c => new FindAllClienteResponse(c.Name, c.BirthdayDate, c.DriverLicense)); ;
            }

            return new List<FindAllClienteResponse>();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Create([FromBody] SaveClientRequest request)
        {
            var client = await _saveClient.Execute(new SaveClientDto(request.Name, request.Cpf, request.BirthdayDate, request.DriverLicense) 
            {
                Address = new SaveOrUpdateAddressDto
                (                    
                    request.Address.Street,
                    request.Address.Number,
                    request.Address.Neighborhood,
                    request.Address.Complement,
                    request.Address.ZipCode,
                    request.Address.CityId
                ) 
            });

            if (client)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("update-address/{id}")]
        public async Task<ActionResult> UpdateAddress([FromRoute]int id, [FromBody] UpdateAddressRequest request)
        {
           var result = await _updateAddress.Execute(new SaveOrUpdateAddressDto
                (
                    id,
                    request.Street,
                    request.Number,
                    request.Neighborhood,
                    request.Complement,
                    request.ZipCode,
                    request.ClientId.Value,
                    request.CityId
                ));

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
