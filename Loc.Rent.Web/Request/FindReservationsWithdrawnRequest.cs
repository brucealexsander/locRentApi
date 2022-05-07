using System;

namespace Loc.Rent.Web.Request
{
    public class FindReservationsWithdrawnRequest
    {
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
    }
}
