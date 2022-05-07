using FluentValidation;
using Loc.Rent.Web.Request;
using System;

namespace Loc.Rent.Web.Validations
{
    public class FindReservationsWithdrawnRequestValidation : AbstractValidator<FindReservationsWithdrawnRequest>
    {
        public FindReservationsWithdrawnRequestValidation()
        {
            RuleFor(f => f.InitialDate).GreaterThan(DateTime.Now);
            RuleFor(f => f.FinalDate).GreaterThan(f => f.InitialDate);
        }
    }
}
