using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.ApplicationCore.Gateways.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loc.Rent.Infrastructure.Repositories
{
    public interface IReservationRepository : IBaseRepository
    {
        Task<IEnumerable<Reservation>> FindReservationsWithdrawn(DateTime? initialDate, DateTime? finalDate);
    }
}
