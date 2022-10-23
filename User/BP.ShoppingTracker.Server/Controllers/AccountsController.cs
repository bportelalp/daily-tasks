using BP.ShoppingTracker.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BP.ShoppingTracker.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] UserInfoDTO userInfo)
        {
            try
            {
                var user = new IdentityUser()
                {
                    UserName = userInfo.Username,
                    Email = userInfo.Email,
                };
                var result = await userManager.CreateAsync(user, userInfo.Password);
                if (result.Succeeded)
                    return Ok(BuildToken(userInfo));
                else
                    return BadRequest("usuario o contraseña inválido");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserInfoDTO userInfo)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(userInfo.Username, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                    return Ok(BuildToken(userInfo));
                else
                    return BadRequest("no logeado");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private UserTokenDTO BuildToken(UserInfoDTO userInfo)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(ClaimTypes.Name, userInfo.Email),
                new Claim("miValor","miloquesea"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);
            return new UserTokenDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
