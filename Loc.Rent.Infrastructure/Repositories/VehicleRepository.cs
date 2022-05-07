using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loc.Rent.Infrastructure.Repositories
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        ISession _session;

        public VehicleRepository(ISession session) : base(session) 
        {
            _session = session;
        }

        public async Task<bool> Exists(int id)
        {
            return _session.Query<Vehicle>().Any(f=> f.Id == id);
        }

        public async Task<IList<string>> FindAllVehiclesWithReturnDateExpired()
        {
            return  await Task.Run(() =>
            {
                Vehicle vehicle = null;
                Reservation reservation = null;

                var query = _session.QueryOver(() => vehicle)
                    .JoinAlias(() => vehicle.Reservations, () => reservation);

                query = query.Where(v => reservation.ExpectedDateReturn < DateTime.Now && reservation.ReturnDate == null);

                return query.SelectList(list => list.Select(c => c.Plate)).List<string>();
            });
        }
    }
}
