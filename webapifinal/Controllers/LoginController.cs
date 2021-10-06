using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using webapifinal.Models;

namespace webapifinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration configuration;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            //Validate the loggged in user
            if ((loginModel.UserName == "User" || loginModel.UserName == "Admin") && loginModel.Password == "pwd@1234")
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("TokenAuthentication:SecretKey").Value));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                  issuer: configuration.GetSection("TokenAuthentication:Issuer").Value,
                  null,
                  expires: DateTime.Now.AddMinutes(60),
                  claims: new List<Claim> { new Claim(ClaimTypes.Role, loginModel.UserName == "Admin" ? "Admin" : "GeneralUser") },
                  signingCredentials: credentials);

                var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Success = true, token = stringToken });

            }
            return Unauthorized();
        }
    }
}
