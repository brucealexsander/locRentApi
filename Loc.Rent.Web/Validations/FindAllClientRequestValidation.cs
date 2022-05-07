using Caelum.Stella.CSharp.Validation;
using FluentValidation;
using Loc.Rent.Web.Request;

namespace Loc.Rent.Web.Validations
{
    public class FindAllClientRequestValidation : AbstractValidator<FindAllClientRequest>
    {
        public FindAllClientRequestValidation(CPFValidator cpfValidator)
        {            
            RuleFor(x => x.Cpf).Length(11, 14);
            RuleFor(x => x.Cpf).Must(cpf => cpf == null ? true : cpfValidator.IsValid(cpf));
            RuleFor(x => x.Name).Length(0, 255);            
        }
    }
}
