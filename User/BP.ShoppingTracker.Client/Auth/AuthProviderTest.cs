using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BP.ShoppingTracker.Client.Auth
{
    public class AuthProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonymous = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Felipe"),
                new Claim(ClaimTypes.Role, "admin")
            });
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }
    }
}
