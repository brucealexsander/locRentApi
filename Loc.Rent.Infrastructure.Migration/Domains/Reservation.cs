using Loc.Rent.Domain.Entities.Base;
using System;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class Reservation : EntityBase
    {
        public virtual DateTime WithdrawalDate { get; set; }
        public virtual DateTime ExpectedDateReturn { get; set; }
               
        public virtual Vehicle Vehicle { get; set; }
        public virtual Client Client { get; set; }
    }
}
