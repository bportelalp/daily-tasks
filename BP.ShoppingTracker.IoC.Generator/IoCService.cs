using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP.ShoppingTracker.Adaptables;
using BP.ShoppingTracker.DataService;
using BP.ShoppingTracker.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BP.ShoppingTracker.IoC.Generator
{
    public static class IoCService
    {
        public static void ConfigureIoC(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ShoppingTrackerContext>(builder => UseDatabaseProvider(builder,configuration));
            services.AddScoped<IDataService, DataService.DataService>();
            services.AddScoped<IGenerator, Adapters.Generator.Generator>();
        }

        public static void UseDatabaseProvider(DbContextOptionsBuilder builder, IConfiguration configuration)
        {
            var databaseProvider = configuration.GetSection("UseDatabaseProvider").Value;
            var connection = configuration.GetConnectionString($"BP.ShoppingTracker.{databaseProvider}");
            switch (databaseProvider)
            {
                case "MSSql": builder.UseSqlServer(connection); break;
                case "PostgreSQL": builder.UseNpgsql(connection); break;
                default: throw new PlatformNotSupportedException($"The database provider is not supported: {databaseProvider}");
            }
            builder.EnableSensitiveDataLogging();
        }

    }
}
