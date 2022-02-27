using JWTDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            if(user == null)
            {
                return BadRequest("Invalid Client Request");
            }

            if(user.Username == "sahil" && user.Password == "sa1234")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer : "https://localhost:7073",
                    audience : "https://localhost:7073",
                    claims : new List<Claim>(),
                    expires : DateTime.Now.AddMinutes(5),
                    signingCredentials : signinCredentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString }); 
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
