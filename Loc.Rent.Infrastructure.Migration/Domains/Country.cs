using Loc.Rent.Domain.Entities.Base;
using System.Collections.Generic;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class Country : EntityBase
    {
        public virtual string Name { get; set; }

        public virtual ISet<State> States { get; set; } = new HashSet<State>();
    }
}
