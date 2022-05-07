using System;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.UseCases.Abstractions
{
    public interface IUpdateReservation
    {
        Task<bool> Execute(int reservationId, DateTime withdrawalDate, DateTime? expectedReturnDate);
        Task<bool> Execute(int reservationId, DateTime returnDate);
    }
}
