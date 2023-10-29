using Microsoft.Extensions.DependencyInjection;

namespace Audote.Server.Application.Extensions
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ServiceColletionExtensions).Assembly);
            });
            return services;
        }
    }
}
