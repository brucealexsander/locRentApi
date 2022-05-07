using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Domains.Dto;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.Gateways.Base;
using Loc.Rent.ApplicationCore.UseCases.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.UseCases
{
    public class RegisterReservation : IRegisterReservation
    {
        private readonly IReservationGateway _reservationGateway;
        private readonly IBaseRepository _baseRepository;
        private readonly IClientGateway _clientGateway;
        private readonly IVehicleGateway _vehicleGateway;
        public RegisterReservation(IReservationGateway reservationGateway, IBaseRepository baseRepository, IVehicleGateway vehicleGateway, IClientGateway clientGateway)
        {
            _clientGateway = clientGateway;
            _vehicleGateway = vehicleGateway;
            _reservationGateway = reservationGateway;
            _baseRepository = baseRepository;            
        }

        public async Task<bool> Execute(RegisterReservationDto request)
        {
            if (request.ImmediateWithdrawal && request.ExpectedReturnDate.Date < DateTime.Now.Date)
            {
                throw new Exception("Expected return date cannot be lower than withdrawal date");
            }

            var reservations = await _baseRepository.FindAllAsync<Reservation>(r=> r.Vehicle.Id == request.VehicleId);

            if (reservations.Where(r=> r.ReturnDate == null).Any())
            {
                throw new Exception("The selected vehicle has not yet been returned.");
            }

            if (!await _vehicleGateway.Exists(request.VehicleId))
            {
                throw new Exception("Vehicle not exists");
            }

            if (!await _clientGateway.Exists(request.ClientId))
            {
                throw new Exception("Client not exists");
            }

            var reservation = new Reservation();

            reservation.Date = DateTime.Now;
            reservation.WithdrawalDate = request.ImmediateWithdrawal ? DateTime.Now : null;
            reservation.Client = new Client(request.ClientId);
            reservation.Vehicle = new Vehicle(request.VehicleId);
            reservation.ExpectedDateReturn = request.ExpectedReturnDate;            

            return await _reservationGateway.RegisterReservation(reservation);
        }
    }
}
