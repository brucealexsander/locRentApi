using Loc.Rent.Domain.Entities.Base;
using System;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class Reservation : EntityBase
    {
        public Reservation()
        {

        }

        public Reservation(int id) : base(id)
        {

        }
        public virtual DateTime Date { get; set; }
        public virtual DateTime? WithdrawalDate { get; set; }
        public virtual DateTime ExpectedDateReturn { get; set; }
        public virtual DateTime? ReturnDate { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Client Client { get; set; }
    }
}
