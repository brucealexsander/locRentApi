using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loc.Rent.Infrastructure.Gateways
{
    public class ReservationGateway : IReservationGateway
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationGateway(IReservationRepository reservationRepository) => _reservationRepository = reservationRepository;

        public Task<bool> RegisterReservation(Reservation reservation)
        {
            return _reservationRepository.SaveOrUpdate(reservation);
        }

        public async Task<IEnumerable<Reservation>> FindAllByClient(int clientId)
        {
            return await _reservationRepository.FindAllAsync<Reservation>(r => r.Client.Id == clientId);
        }

        public async Task<IEnumerable<Reservation>> FindReservationsWithdrawn(DateTime? initialDate, DateTime? finalDate)
        {
            return await _reservationRepository.FindReservationsWithdrawn(initialDate, finalDate);
        }

        public Task<Reservation> FindById(int reservationId)
        {
            return _reservationRepository.FindByIdAsync<Reservation>(reservationId);
        }

        public Task<bool> UpdateReservation(Reservation reservation)
        {
            return _reservationRepository.SaveOrUpdate(reservation);
        }
    }
}
