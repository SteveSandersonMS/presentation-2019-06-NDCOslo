using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MissionControl.Shared;

namespace MissionControl.Server.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("api/user/login")]
        public LoginResult LogIn(LoginCredentials credentials)
        {
            return ValidateCredentials(credentials)
                ? new LoginResult { Token = GenerateJWT(credentials.UserName) }
                : LoginResult.Unauthorized;
        }

        private bool ValidateCredentials(LoginCredentials credentials)
            => credentials.Password?.Length > 3; // TODO: connect to some underlying store

        private string GenerateJWT(string username)
        {
            // Also consider using AsymmetricSecurityKey if you want the client to be able to validate the token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                new[] { new Claim(ClaimTypes.Name, username) },
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
