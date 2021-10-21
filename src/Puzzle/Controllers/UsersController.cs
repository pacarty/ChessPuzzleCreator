using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Puzzle.Data;
using Puzzle.Models;
using Puzzle.Services;

namespace Puzzle.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _svc;

        public UsersController(IUserService svc)
        {
            _svc = svc;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser(string username, string password)
        {
            _svc.RegisterUser(username, password);

            return Ok();
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate(string username, string password)
        {
            User user = _svc.Authenticate(username, password);

            var tokenHandler = new JwtSecurityTokenHandler();

            // TODO: Have better way of storing the random string
            var key = Encoding.ASCII.GetBytes("Random String Patrick Carty");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                Token = tokenString
            });
        }
    }
}