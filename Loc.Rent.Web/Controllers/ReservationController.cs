using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Domains.Dto;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.UseCases.Abstractions;
using Loc.Rent.Web.Request;
using Loc.Rent.Web.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Loc.Rent.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : Controller
    {
        private readonly IRegisterReservation _registerReservation;
        private readonly IReservationGateway _reservationGateway;
        private readonly IUpdateReservation _updateReservation;

        public ReservationController(IRegisterReservation registerReservation, IReservationGateway reservationGateway, IUpdateReservation updateReservation)
        {
            _registerReservation = registerReservation;
            _reservationGateway = reservationGateway;
            _updateReservation = updateReservation;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Create([FromBody] RegisterReservationRequest request)
        {
            var reservation = await _registerReservation.Execute(new RegisterReservationDto(request.ClientId, request.VehicleId, request.ImmediateWithdrawal, request.ExpectedReturnDate));

            if (reservation)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("/clientId/{clientId}")]
        public async Task<IEnumerable<FindAllReservationsByClientResponse>> FindAllByClient([FromRoute] int clientId)
        {
            var reservations = await _reservationGateway.FindAllByClient(clientId);

            return reservations.Any()
                ? reservations.Select(r => new FindAllReservationsByClientResponse(r.Id, r.Date, r.WithdrawalDate, r.ExpectedDateReturn, r.ReturnDate, r.Vehicle.Description, r.Vehicle.Plate))
                : new List<FindAllReservationsByClientResponse>();
        }

        [HttpGet("find-withdrawn-by-period")]
        public async Task<IEnumerable<FindReservationsWithdrawnResponse>> FindReservationsWithdrawn([FromQuery] FindReservationsWithdrawnRequest request)
        {
            var reservations = await _reservationGateway.FindReservationsWithdrawn(request.InitialDate, request.FinalDate);

            return reservations.Any()
                ? reservations.Select(r => new FindReservationsWithdrawnResponse(r.Id, r.Date, r.WithdrawalDate, r.ExpectedDateReturn, r.Vehicle.Description, r.Vehicle.Plate))
                : new List<FindReservationsWithdrawnResponse>();
        }

        [HttpPut("/{reservationId}")]
        public async Task<ActionResult> UpdateReservation(int reservationId, DateTime withdrawalDate, DateTime? expectedReturnDate)
        {
            var result = await _updateReservation.Execute(reservationId, withdrawalDate, expectedReturnDate);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("return-vehicle/{reservationId}")]
        public async Task<ActionResult> UpdateReservation(int reservationId, DateTime returnDate)
        {
            var result = await _updateReservation.Execute(reservationId, returnDate);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
