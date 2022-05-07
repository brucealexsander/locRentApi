using FluentValidation;
using Loc.Rent.Web.Request;
using System;

namespace Loc.Rent.Web.Validations
{
    public class RegisterReservationRequestValidation : AbstractValidator<RegisterReservationRequest>
    {
        public RegisterReservationRequestValidation()
        {
            RuleFor(x => x.ClientId).NotNull();
            RuleFor(x => x.VehicleId).NotNull();
            RuleFor(x => x.ExpectedReturnDate).NotNull().GreaterThan(DateTime.Now);            
        }
    }
}
