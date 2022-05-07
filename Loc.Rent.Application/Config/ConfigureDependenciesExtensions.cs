using Loc.Rent.ApplicationCore.UseCases;
using Loc.Rent.ApplicationCore.UseCases.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Loc.Rent.ApplicationCore.Config
{
    public static class ConfigureDependenciesExtensions
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISaveClient, SaveClient>();
            services.AddScoped<IUpdateAddress, UpdateAddress>();
            services.AddScoped<ISaveVehicle, SaveVehicle>();
            services.AddScoped<IRegisterReservation, RegisterReservation>();
            services.AddScoped<IUpdateReservation, UpdateReservation>();
        }
    }
}
