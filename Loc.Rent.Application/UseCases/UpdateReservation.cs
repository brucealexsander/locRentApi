using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.UseCases.Abstractions;
using System;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.UseCases
{
    public class UpdateReservation : IUpdateReservation
    {
        private readonly IReservationGateway _reservationGateway;

        public UpdateReservation(IReservationGateway reservationGateway)
        {
            _reservationGateway = reservationGateway;
        }

        public async Task<bool> Execute(int reservationId, DateTime withdrawalDate, DateTime? expectedReturnDate)
        {
            if (withdrawalDate == DateTime.MinValue)
            {
                throw new Exception("Please insert withdrawal date and expected return date");
            }

            if (expectedReturnDate < withdrawalDate)
            {
                throw new Exception("Expected return date cannot be lower than withdrawal date");
            }

            var reservation = await GetReservation(reservationId);

            if (reservation.ReturnDate != null)
            {
                throw new Exception("The vehicle already returned");
            }

            if (withdrawalDate.Date > DateTime.Now.Date)
            {
                throw new Exception("The withdrawal date cannot be later than today");
            }

            reservation.WithdrawalDate = withdrawalDate;
            reservation.ExpectedDateReturn = expectedReturnDate ?? reservation.ExpectedDateReturn;

            return await _reservationGateway.UpdateReservation(reservation);
        }

        public async Task<bool> Execute(int reservationId, DateTime returnDate)
        {
            if (returnDate.Date > DateTime.Now.Date)
            {
                throw new Exception("The returnDate date cannot be later than today");
            }

            var reservation = await GetReservation(reservationId);

            reservation.ReturnDate = returnDate;            

            return await _reservationGateway.UpdateReservation(reservation);
        }

        private Task<Reservation> GetReservation(int reservationId)
        {
            var reservation = _reservationGateway.FindById(reservationId);

            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            return reservation;
        }
    }
}
