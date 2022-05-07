using Loc.Rent.ApplicationCore.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.Gateways
{
    public interface IReservationGateway
    {
        Task<Reservation> FindById(int reservationId);
        Task<bool> UpdateReservation(Reservation reservation);
        Task<bool> RegisterReservation(Reservation reservation);
        Task<IEnumerable<Reservation>> FindAllByClient(int clientId);
        Task<IEnumerable<Reservation>> FindReservationsWithdrawn(DateTime? initialDate, DateTime? finalDate);
    }
}