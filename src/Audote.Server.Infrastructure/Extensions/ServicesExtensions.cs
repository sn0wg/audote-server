using Audote.Server.Infrastructure.Repository.Animals;
using Audote.Server.Infrastructure.Repository.Pictures;
using Audote.Server.Infrastructure.Settings;
using Audote.Server.Infrastructure.Storages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Audote.Server.Infrastructure.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddInfrastructureConfig(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<RepositorySettings>((options) =>
            {
                options.ConnectionString = config.GetConnectionString("SqlDb") ?? "";
            });

            services.Configure<StorageSettings>((options) =>
            {
                var section = config.GetRequiredSection(nameof(StorageSettings));

                section.Bind(options);
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IPictureRepository, PictureSqlRepository>();
            services.AddSingleton<IAnimalRepository, AnimalSqlRepository>();

            return services;
        }

        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddSingleton<IStorage, FileStorage>();

            return services;
        }
    }
}
