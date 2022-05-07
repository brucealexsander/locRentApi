using Loc.Rent.Domain.Entities.Base;

namespace Loc.Rent.Domain.Entities
{
    public class Cidade : EntityBase
    {
        public virtual string Nome { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
