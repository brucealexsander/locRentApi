using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loc.Rent.Infrastructure.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        private readonly ISession _session;
        public ClientRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public async Task<bool> Exists(int id)
        {
            return _session.Query<Vehicle>().Any(f => f.Id == id);
        }
    }
}
