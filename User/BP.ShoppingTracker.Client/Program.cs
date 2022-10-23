using BP.Components.Blazor.UI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BP.ShoppingTracker.Client.Auth;
using BP.ShoppingTracker.Client;
using BP.Components.RepositoryClient;

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
            builder.Services.AddAuthorizationCore();
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