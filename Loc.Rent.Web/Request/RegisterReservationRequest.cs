using System;

namespace Loc.Rent.Web.Request
{
    public class RegisterReservationRequest
    {
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public bool ImmediateWithdrawal { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }
}
