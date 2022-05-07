using Loc.Rent.Domain.Entities.Base;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class City : EntityBase
    {
        public City() { }
        public City(int id) : base(id) { }

        public virtual string Name { get; set; }
        public virtual State State { get; set; }
    }
}
