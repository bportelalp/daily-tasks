using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BP.ShoppingTracker.IoC.Server
{
    public static class IoCService
    {
        public static void ConfigureIoC(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<I30.Persistence.Context.ShoppingTrackerContext>(builder => UseDatabaseProvider(builder, configuration));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<I30.Persistence.Context.ShoppingTrackerContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"])),
                    ClockSkew = TimeSpan.Zero
                });
            services.AddScoped<D20.Adapters.IDataService, I31.DataService.DataService>();
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
            bool enableDataLogging = configuration.GetValue<bool>("EnableEFCoreDataLogging");
            builder.EnableSensitiveDataLogging(enableDataLogging);
        }
    }
}
