using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loc.Rent.Infrastructure.Repositories
{
    public class ReservationRepository : BaseRepository, IReservationRepository
    {
        private readonly ISession _session;

        public ReservationRepository(ISession session) : base(session) => _session = session;

        public async Task<IEnumerable<Reservation>> FindReservationsWithdrawn(DateTime? initialDate, DateTime? finalDate)
        {
                Reservation reservation = null;

                var query = _session.QueryOver(() => reservation);

                query = query.And(r => r.WithdrawalDate != null);

                if (initialDate != null)
                {
                    query = query.And(r => r.WithdrawalDate >= initialDate.Value.AddHours(00).AddMinutes(00));
                }

                if (finalDate != null)
                {
                    query = query.And(r => r.WithdrawalDate <= initialDate.Value.AddHours(23).AddMinutes(59));
                }

                return await query.ListAsync();
        }
    }
}
