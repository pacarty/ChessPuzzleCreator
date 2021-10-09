using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
    }
}