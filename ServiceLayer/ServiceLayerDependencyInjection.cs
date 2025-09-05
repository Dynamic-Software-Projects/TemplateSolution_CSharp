using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.HttpService;
using ServiceLayer.Interfaces.HttpService;
using ServiceLayer.Interfaces.ModelCreatorService;
using ServiceLayer.Interfaces.ValidationService;
using ServiceLayer.ModelCreatorService;
using ServiceLayer.ValidationService;

namespace ServiceLayer
{
    public static class ServiceLayerDependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<IHttpResponseService, HttpResponseService>();
            services.AddTransient<IInputValidatorService, InputValidatorService>();
            services.AddTransient<IValuesModelCreatorService, ValuesModelCreatorService>();
            services.AddTransient<IHttpResponseCreatorService, HttpResponseCreatorService>();

            return services;
        }
    }
}
