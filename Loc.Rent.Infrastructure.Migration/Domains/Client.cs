using Loc.Rent.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class Client : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string Cpf { get; set; }
        public virtual DateTime BirthdayDate { get; set; }
        public virtual string DriverLicense { get; set; }
        public virtual ISet<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
