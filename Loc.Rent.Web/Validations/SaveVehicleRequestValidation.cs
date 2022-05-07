using FluentValidation;
using Loc.Rent.Web.Request;

namespace Loc.Rent.Web.Validations
{
    public class SaveVehicleRequestValidation : AbstractValidator<SaveVehicleRequest>
    {
        public SaveVehicleRequestValidation()
        {
            RuleFor(x => x.Description).NotEmpty().NotNull().Length(2, 255);
            RuleFor(x => x.ManufactureYear).NotNull();
            RuleFor(x => x.ModelYear).NotNull();
            RuleFor(x => x.Plate).NotNull().NotEmpty().Length(7, 8);
            RuleFor(x => x.ModelId).NotNull();
        }
    }
}
