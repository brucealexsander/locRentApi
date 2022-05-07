using Loc.Rent.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class Client : EntityBase
    {
        public Client() { }
        public Client(int id) : base(id) { }

        public virtual string Name { get; set; }
        public virtual string Cpf { get; set; }
        public virtual DateTime BirthdayDate { get; set; }
        public virtual string DriverLicense { get; set; }

        public virtual Address Address { get; set; }
        public virtual ISet<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
