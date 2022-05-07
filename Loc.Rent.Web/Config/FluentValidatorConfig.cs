using FluentValidation.AspNetCore;
using Loc.Rent.Web.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace Loc.Rent.Web.Config
{
    public static class FluentValidatorConfig
    {
        public static void ConfigureFluentValidator(this IServiceCollection services)
        {
            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<FindAllClientRequestValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<FindReservationsWithdrawnRequestValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<RegisterReservationRequestValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<SaveClientRequestValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<SaveVehicleRequestValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<UpdateAddressRequestValidation>();
                });
        }
    }
}
