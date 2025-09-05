using ApplicationLayer.Adapters;
using ApplicationLayer.Interfaces.Adapters;
using ApplicationLayer.Interfaces.Managers;
using ApplicationLayer.Interfaces.Session;
using ApplicationLayer.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer
{
    public static class ApplicationLayerDependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<Login, SessionManager>();
            services.AddTransient<Logout, SessionManager>();
            services.AddTransient<IValuesManager, ValuesManager>();
            services.AddTransient<IValuesAdapter, ValuesAdapter>();
            services.AddTransient<IRegistrationManager, RegistrationManager>();

            return services;
        }

        public static IServiceCollection AddDataAccessLayerAdaptor(this IServiceCollection services, IConfiguration configuration)
        {
            IServiceCollection processedServices = DataAccessLayer.DataAccessLayerDependencyInjection.AddDataAccessLayer(services, configuration);

            return processedServices;
        }
    }
}
