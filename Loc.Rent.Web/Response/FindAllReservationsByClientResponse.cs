using System;

namespace Loc.Rent.Web.Response
{
    public class FindAllReservationsByClientResponse
    {
        public FindAllReservationsByClientResponse(int id, DateTime date, DateTime? withdrawalDate, DateTime expectedDateReturn, DateTime? returnDate, string vehicle, string vehiclePlate)
        {
            Id = id;
            Date = date;
            WithdrawalDate = withdrawalDate;
            ExpectedDateReturn = expectedDateReturn;
            ReturnDate = returnDate;
            Vehicle = vehicle;
            VehiclePlate = vehiclePlate;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime? WithdrawalDate { get; set; }
        public DateTime ExpectedDateReturn { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Vehicle { get; set; }
        public string VehiclePlate { get; set; }
    }
}
