using Loc.Rent.Domain.Entities.Base;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class Model : EntityBase
    {
        public Model() { }
        public Model(int id) : base(id) { }

        public virtual string Name { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
