using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BP.ShoppingTracker.Adaptables;
using BP.ShoppingTracker.Adapters.Catalogue.DataService;
using BP.ShoppingTracker.Adapters.Catalogue.ORM.Context;
using BP.ShoppingTracker.Adapters.Identity.ORM.Context;
using Microsoft.AspNetCore.Http;

namespace BP.ShoppingTracker.IoC.Server
{
    public static class IoCService
    {
        public static void ConfigureIoC(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ShoppingTrackerContext>(builder => UseDatabaseProvider(builder, configuration));
            services.AddDbContext<ShoppingTrackerIdentityContext>(builder => UseDatabaseProvider(builder, configuration));
            services.AddIdentity<IdentityUser, IdentityRole>()
                //.AddRoles<IdentityRole>()
                //.AddRoleManager<RoleManager<IdentityUser>>()
                .AddEntityFrameworkStores<ShoppingTrackerIdentityContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    string token = configuration["jwt:key"] ?? throw new ApplicationException("Jwt cannot be null");
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token)),
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = async context =>
                        {
                            // Call this to skip the default logic and avoid using the default response
                            context.HandleResponse();

                            // Write to the response in any way you wish
                            context.Response.StatusCode = 401;
                            //context.Response.Headers.Append("my-custom-header", "custom-value");
                            await context.Response.WriteAsync("Not authorized");
                        }
                    };
                });
            services.AddScoped<ICatalogueService, CatalogueDataService>();
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
