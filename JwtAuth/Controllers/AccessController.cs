using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JwtAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class AccessController : ControllerBase
    {
        private readonly IConfiguration _configuration; 
        public AccessController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [AllowAnonymous]
        public string GetToken()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:subject"]),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim("UserId","YourUserId"),
                new Claim("DisplayName","Your Display Name"),
                new Claim("Email","youemail@domain.com")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:issuer"],
                _configuration["Jwt:audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: signIn
                ) ;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    public class UserModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? AccessToken { get; set; }
    }
}
