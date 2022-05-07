using Loc.Rent.Domain.Entities.Base;
using System.Collections.Generic;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class State : EntityBase
    {
        public State() { }
        public State(int id) : base(id) { }
        public virtual string Name { get; set; }
        public virtual string Initials { get; set; }
        public virtual Country Country { get; set; }

        public virtual ISet<City> Cities { get; set; } = new HashSet<City>();
    }
}
