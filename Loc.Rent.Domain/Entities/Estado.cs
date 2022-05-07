using Loc.Rent.Domain.Entities.Base;
using System.Collections.Generic;

namespace Loc.Rent.Domain.Entities
{
    public class Estado : EntityBase
    {
        public virtual string Nome { get; set; }
        public virtual string Sigla { get; set; }
        public virtual Pais Pais { get; set; }

        public virtual ISet<Cidade> Cidades { get; set; } = new HashSet<Cidade>();
    }
}
