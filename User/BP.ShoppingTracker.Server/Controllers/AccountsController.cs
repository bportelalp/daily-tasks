using BP.ShoppingTracker.Models;
using BP.ShoppingTracker.Models.Accounts;
using BP.ShoppingTracker.Models.Accounts.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
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
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly ILogger<AccountsController> logger;

        public AccountsController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ILogger<AccountsController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
            this.logger = logger;
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                List<IdentityRole> identityRoles = await roleManager.Roles.ToListAsync();
                List<RoleDTO> roles = new List<RoleDTO>();
                identityRoles.ForEach(identityRole =>
                {
                    if (identityRole.Name is null)
                        return;
                    RoleDTO role = new RoleDTO() { Name = identityRole.Name };
                    roles.Add(role);
                });

                return Ok(roles);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception getting roles");
                throw;
            }
        }

        [HttpGet("users")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUsers([FromQuery] int? start, [FromQuery] int amount = 10)
        {
            try
            {
                var total = userManager.Users.Count();
                var usersQuery = userManager.Users;
                if (start is not null)
                    usersQuery = usersQuery.Skip(start.Value);
                usersQuery = usersQuery.Take(amount);

                var result = await usersQuery.ToListAsync();
                IEnumerable<User> users = result.Select(r => new User()
                {
                    Id = new Guid(r.Id),
                    Username = r.UserName,
                    Email = r.Email,
                    PhoneNumber = r.PhoneNumber
                });
                return Ok(users);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationDTO userInfo)
        {
            try
            {
                var user = new IdentityUser()
                {
                    UserName = userInfo.Username,
                    Email = userInfo.Email,
                    PhoneNumber = userInfo.PhoneNumber,
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
                    return BadRequest($"User or password incorrect: {textErrors}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception CreateUser");
                throw;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLogin)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(userLogin.Username);
                    var roles = await userManager.GetRolesAsync(user);
                    logger.LogTrace("User {userName} request login", userLogin.Username);
                    var token = BuildToken(userLogin, roles);
                    return Ok(token);
                }
                else
                {
                    logger.LogWarning("User {userName} can't login", userLogin.Username);
                    return BadRequest("no logeado");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception Login");
                throw;
            }
        }

        [HttpPost("role")]
        public async Task<IActionResult> PostCreateRole([FromBody] RoleDTO roleDto)
        {
            try
            {
                var role = new IdentityRole(roleDto.Name);
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    logger.LogTrace("Role {roleName} created", role.Name);
                    return NoContent();
                }
                else
                {
                    var errors = string.Join("|", result.Errors.Select(e => e.Code));
                    logger.LogWarning("Role {roleName} cannot be created due to errors={}", roleDto.Name, errors);
                    return BadRequest(errors);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception on CreateRole");
                throw;
            }
        }

        [HttpPost("set-role")]
        public async Task<IActionResult> PostSetRoleUser([FromBody] EditRoleDTO editRole)
        {
            try
            {
                var user = await userManager.FindByNameAsync(editRole.UserName);


                if (user is null)
                    return BadRequest("The user doesn't exist");

                await userManager.AddToRoleAsync(user, editRole.Role);
                logger.LogTrace("User={userName} assigned to role={roleName}", editRole.UserName, editRole.Role);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception on SetRoleUser");
                throw;
            }
        }

        [HttpPost("remove-role")]
        public async Task<IActionResult> PostRemoveRoleUser([FromBody] EditRoleDTO editRole)
        {
            try
            {
                var user = await userManager.FindByNameAsync(editRole.UserName);

                if (user is null)
                    return BadRequest("The user doesn't exist");

                await userManager.RemoveFromRoleAsync(user, editRole.Role);
                logger.LogTrace("User={userName} removed from role={roleName}", editRole.UserName, editRole.Role);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private UserTokenDTO BuildToken(UserLoginDTO userInfo, IEnumerable<string>? roles = null)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Username),
                new Claim(ClaimTypes.Name, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            if (roles is not null)
            {
                foreach (var role in roles)
                {
                    var claim = new Claim(ClaimTypes.Role, role);
                    claims.Add(claim);
                }
            }
            string jwtKey = configuration["jwt:key"] ?? throw new ApplicationException("JwtKey must be configured on startup");
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(jwtKey));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

            DateTime expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            JwtSecurityTokenHandler tokenHandler = new();
            string tokenJwt = tokenHandler.WriteToken(token);

            return new UserTokenDTO()
            {
                Token = tokenJwt,
                Expiration = expiration
            };
        }
    }
}
