using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReBuyDtos;
using ReBuyModels;

namespace ReBuyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UsersModel> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<UsersModel> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;

        }

        // For Guest

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole));

                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));


                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issue"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
                BadRequest(new { message = "Object pass not valid!!!" });
            
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                var newUser = new UsersModel()
                {
                    UserName = model.Email,
                    FullName = model.Fullname,
                    Email = model.Email,
                    AvatarUrl = "default.jpg",
                    IsActive = true
                    
                };

                var userAdded = await _userManager.CreateAsync(newUser, model.Password);
                if (userAdded.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "Customer");
                    return Ok(new { message = "Register User Successfull" });

                }
                return StatusCode(StatusCodes.Status500InternalServerError, userAdded.Errors);

            }
            return BadRequest(new { message = "User already exist!!!!" });
        }

    }
}
