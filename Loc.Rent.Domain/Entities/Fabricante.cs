using Loc.Rent.Domain.Entities.Base;
using System.Collections.Generic;

namespace Loc.Rent.Domain.Entities
{
    public class Fabricante : EntityBase
    {
        public virtual string Nome { get; set; }

        public virtual ISet<Modelo> Modelos { get; set; } = new HashSet<Modelo>();
    }
}
