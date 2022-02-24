
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using pizza_challenge.API.Extensions;
using pizza_challenge.API.Infrastructure;
using Pizza.Infrastructure;

namespace pizza_challenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();
            var host = CreateHostBuilder(configuration, args);
            host.MigrateDbContext<PizzaContext>((context, services) =>
            {
                new PizzaChallengeContextSeed().SeedAsync(context).Wait();
            });

            host.Run();
        }


        private static IWebHost CreateHostBuilder(IConfiguration configuration, string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
            .UseStartup<Startup>()
            .Build();

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: false)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
