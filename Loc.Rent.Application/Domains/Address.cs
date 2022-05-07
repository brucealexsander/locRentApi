using Loc.Rent.Domain.Entities.Base;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class Address : EntityBase
    {
        public Address()
        {

        }

        public Address(int id) : base(id)
        {

        }
        public virtual string Street { get; set; }
        public virtual string Number { get; set; }
        public virtual string Neighborhood { get; set; }
        public virtual string Complement { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual City City { get; set; }
        public virtual Client Client { get; set; }

    }
}
