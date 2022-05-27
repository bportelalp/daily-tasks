using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BP.ShoppingTracker.IoC.Generator
{
    public static class IoCService
    {
        public static void ConfigureIoC(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<I30.Persistence.Context.ShoppingTrackerContext>(builder => UseDatabaseProvider(builder,configuration));
            services.AddScoped<D20.Adapters.IDataService, I31.DataService.DataService>();
            services.AddScoped<D20.Adapters.IGenerator, I32.Generator.Generator>();
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
            builder.UseSqlServer(connection);
            builder.EnableSensitiveDataLogging();
        }

    }
}
