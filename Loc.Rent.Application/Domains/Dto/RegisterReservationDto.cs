using System;

namespace Loc.Rent.ApplicationCore.Domains.Dto
{
    public class RegisterReservationDto
    {
        public RegisterReservationDto(int clientId, int vehicleId, bool immediateWithdrawal, DateTime expectedReturnDate)
        {
            ClientId = clientId;
            VehicleId = vehicleId;
            ImmediateWithdrawal = immediateWithdrawal;
            ExpectedReturnDate = expectedReturnDate;
        }

        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public bool ImmediateWithdrawal { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }
}
