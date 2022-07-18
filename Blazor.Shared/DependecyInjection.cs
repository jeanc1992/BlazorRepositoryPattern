using Blazor.Domain.Interfaces.Repositories;
using Blazor.Domain.Interfaces.Services;
using Blazor.Domain.Services;
using Blazor.Shared.Data;
using Blazor.Shared.Data.Repositories;
using Blazor.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Shared
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAppShared(this IServiceCollection service)
        {
            service.AddRepos().AddServices();
            return service;

        }



        public static IServiceCollection AddDbContext(this IServiceCollection service, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            service.AddDbContextFactory<BlazorDbContext>(options =>
            {
                options.UseMySql(connectionString, serverVersion);


            });

            return service;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IAppDataService, AppDataService>();
            services.AddSingleton<IClientService, ClientService>();
            return services;
        }


        private static IServiceCollection AddRepos(this IServiceCollection services)
        {

            services.AddSingleton<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
