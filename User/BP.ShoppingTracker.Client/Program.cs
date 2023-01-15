using BP.Components.Blazor.UI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BP.ShoppingTracker.Client.Auth;
using BP.ShoppingTracker.Client;
using BP.Components.RepositoryClient;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace BP.ShoppingTracker.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");


            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("PersonalData", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Name)
                    .RequireAssertion(context =>
                    {
                        var userName = context.User.FindFirst(JwtRegisteredClaimNames.UniqueName).Value;
                        return true;
                    });
                });
            });
            builder.Services.AddScoped<AuthProviderJwt>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthProviderJwt>(provider => provider.GetRequiredService<AuthProviderJwt>());
            builder.Services.AddScoped<ILoginService, AuthProviderJwt>(provider => provider.GetRequiredService<AuthProviderJwt>());
            builder.Services.AddScoped<IRepoClient, RepoClient>();
            //builder.Services.AddScoped<BP.Components.Blazor.UI.FrontendUtils.LocalStorageService>();
            //builder.Services.AddTransient<BP.Components.Blazor.UI.FrontendUtils.PopUp>();
            builder.Services.ConfigureBlazorUIServices();



            await builder.Build().RunAsync();
        }
    }
}