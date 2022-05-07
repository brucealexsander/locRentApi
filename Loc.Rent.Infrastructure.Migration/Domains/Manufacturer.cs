using Loc.Rent.Domain.Entities.Base;
using System.Collections.Generic;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class Manufacturer : EntityBase
    {
        public virtual string Name { get; set; }

        public virtual ISet<Model> Models { get; set; } = new HashSet<Model>();
    }
}
