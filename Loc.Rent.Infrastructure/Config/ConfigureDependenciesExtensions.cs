using Loc.Rent.ApplicationCore.Gateways;
using Loc.Rent.ApplicationCore.Gateways.Base;
using Loc.Rent.Infrastructure.Gateways;
using Loc.Rent.Infrastructure.Repositories;
using Loc.Rent.Infrastructure.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Loc.Rent.Infrastructure.Config
{
    public static class ConfigureDependenciesExtensions
    {
        public static void ConfigureInfraDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository), typeof(BaseRepository));
            services.AddScoped<IClientGateway, ClientGateway>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IVehicleGateway, VehicleGateway>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IReservationGateway, ReservationGateway>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
        }
    }
}
