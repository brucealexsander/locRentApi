using Loc.Rent.Domain.Entities.Base;
using System.Collections.Generic;

namespace Loc.Rent.Domain.Entities
{
    public class Pais : EntityBase
    {
        public virtual string Nome { get; set; }

        public virtual string Sigla { get; set; }        

        public virtual ISet<Estado> Estados { get; set; } = new HashSet<Estado>();
    }
}
