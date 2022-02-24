using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace pizza_challenge.API.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext>(this IWebHost host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation("Migrating database");
                    InvokeSeeder(seeder, context, services);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating Euromonitor database");
                }
            }

            return host;
        }


        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
          where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}
