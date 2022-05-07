using Caelum.Stella.CSharp.Validation;
using FluentValidation;
using Loc.Rent.Web.Request;
using System;

namespace Loc.Rent.Web.Validations
{
    public class SaveClientRequestValidation : AbstractValidator<SaveClientRequest>
    {
        public SaveClientRequestValidation(CPFValidator cpfValidator)
        {
            RuleFor(x => x.Cpf).Length(11, 14).NotNull().NotEmpty().Must(cpf => cpfValidator.IsValid(cpf));
            RuleFor(x => x.BirthdayDate).NotNull().GreaterThan(DateTime.Now).NotEqual(DateTime.MinValue);
            RuleFor(x => x.Name).NotNull().Length(2, 255);
            RuleFor(x => x.DriverLicense).NotNull().Length(8, 20);
            RuleFor(x => x.Address).SetValidator(new UpdateAddressRequestValidation());
        }
    }
}
