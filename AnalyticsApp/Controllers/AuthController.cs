using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AnalyticsApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AnalyticsApp.Controllers
{
    [Produces("application/json")]
    public class AuthController : Controller
    {
        private readonly AnalyticsAppContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(AnalyticsAppContext context, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("/api/auth/register")]
        public async Task<object> Register()
        {
            var user = new User
            {
                UserName = "demo"
            };

            await _userManager.CreateAsync(user, "demo12345");

            return Ok();
        }

        [HttpPost]
        [Route("/api/auth/login")]
        public async Task<IActionResult> PostLogin(LoginUser _loginUser)
        {
            var user = await _userManager.FindByNameAsync(_loginUser.Username);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, _loginUser.Password, false);

            if (result.Succeeded)
            {
                return GenerateJwtToken(user);
            }

            return NotFound();
        }

        private IActionResult GenerateJwtToken(User _user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(30);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }

    public class LoginUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}