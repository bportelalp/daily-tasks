using BP.ShoppingTracker.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Configuration;
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
        private readonly ILogger<AccountsController> logger;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, ILogger<AccountsController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.logger = logger;
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
                {
                    logger.LogTrace("User created;User={userName}", user.UserName);
                    var token = BuildToken(userInfo);
                    return Ok(token);
                }
                else
                {
                    string textErrors = string.Join("|", result.Errors.Select(e => e.Code));
                    logger.LogWarning("User cannot be created;User={};Reason={}", user.UserName, textErrors);
                    return BadRequest($"usuario o contraseña inválido: {textErrors}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception CreateUser");
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
                {
                    logger.LogTrace("User {userName} request login", userInfo.Username);
                    var token = BuildToken(userInfo);
                    return Ok(BuildToken(userInfo));
                }
                else
                {
                    logger.LogWarning("User {userName} can't login", userInfo.Username);
                    return BadRequest("no logeado");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception Login");
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
