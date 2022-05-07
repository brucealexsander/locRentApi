using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loc.Rent.Web.Response
{
    public class FindReservationsWithdrawnResponse
    {
        public FindReservationsWithdrawnResponse(int id, DateTime date, DateTime? withdrawalDate, DateTime expectedDateReturn, string vehicle, string vehiclePlate)
        {
            Id = id;
            Date = date;
            WithdrawalDate = withdrawalDate;
            ExpectedDateReturn = expectedDateReturn;
            Vehicle = vehicle;
            VehiclePlate = vehiclePlate;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime? WithdrawalDate { get; set; }
        public DateTime ExpectedDateReturn { get; set; }
        public string Vehicle { get; set; }
        public string VehiclePlate { get; set; }
    }
}
