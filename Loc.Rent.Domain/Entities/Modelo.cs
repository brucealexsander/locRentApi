using Loc.Rent.Domain.Entities.Base;

namespace Loc.Rent.Domain.Entities
{
    public class Modelo : EntityBase
    {
        public virtual  string Nome { get; set; }
        public virtual Fabricante Fabricante { get; set; }
    }
}
