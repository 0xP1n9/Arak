using Arak.BLL.DTO;
using Arak.BLL.Service.Abstraction;
using Arak.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Arak.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly IConfiguration configuration;
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
            this.configuration = configuration;
        }

        

        [HttpPost("CreateNewUser")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> CreateNewUser(DtoNewUser user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new()
                {
                    Name = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };
                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, user.Role);

                    return Ok("Success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(DtoLogin login)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(login.Email);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, login.Password))
                    {
                        var claims = new List<Claim>();
                        //claims.Add(new Claim("name", "value"));
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        var roles = await _userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                        }

                        //signingCredentials
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: configuration["JWT:Issure"],
                            audience: configuration["JWT:Audience"],
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: signingCredentials
                            );

                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                        };
                        return Ok(_token);

                    }
                    else
                    {
                        return Unauthorized();
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Email is invalid");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);

            if (!result)
                return NotFound("User not found");

            return Ok("User soft deleted");
        }
    }
}
