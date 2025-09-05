using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DataAccessLayerDependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(IServiceCollection services, IConfiguration configuration)
        {

            services.AddKeyedTransient<IBaseRepository, SessionRepository>("Session");
            services.AddKeyedTransient<IBaseRepository, UserRepository>("User");
            return services;
        }
    }
}
