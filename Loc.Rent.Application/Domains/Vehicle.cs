using Loc.Rent.Domain.Entities.Base;
using System.Collections.Generic;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class Vehicle : EntityBase
    {
        public Vehicle() { }
        public Vehicle(int id) : base(id) { }

        public virtual string Plate { get; set; }
        public virtual string Description { get; set; }  
        public virtual int ManufactureYear { get; set; }
        public virtual int ModelYear { get; set; }

        public virtual Model Model { get; set; }
        public virtual ISet<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
