using Blazor.Shared.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Shared.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder ApplyAppMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BlazorDbContext>();
                db.Database.Migrate();
            }

            return app;

        }
    }
}
