using FluentValidation;
using Loc.Rent.Web.Request;

namespace Loc.Rent.Web.Validations
{
    public class UpdateAddressRequestValidation : AbstractValidator<UpdateAddressRequest>
    {
        public UpdateAddressRequestValidation()
        {
            RuleFor(x => x.Street).NotNull().Length(1, 255);
            RuleFor(x => x.Number).NotNull().Length(1, 255);
            RuleFor(x => x.Neighborhood).NotNull().Length(1, 255);
            RuleFor(x => x.ZipCode).NotNull().Length(1, 255);
            RuleFor(x => x.Complement).NotNull().Length(1, 255);
            RuleFor(x => x.CityId).NotNull();
        }
    }
}
