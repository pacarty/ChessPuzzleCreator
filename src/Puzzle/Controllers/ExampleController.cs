using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Puzzle.Data;
using Puzzle.Models;

namespace Puzzle.Controllers
{
    [Route("api/[controller]")]
    public class ExampleController : Controller
    {
        private DataContext _context;

        public ExampleController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("GetModels")]
        public IActionResult GetModels()
        {
            var result = _context.ExampleModels.ToList();

            return Ok(result);
        }

        [HttpPost]
        [Route("PostModel")]
        public IActionResult PostModel(ExampleModel model)
        {
            _context.ExampleModels.Add(model);
            _context.SaveChanges();

            return Ok();
        }
    }
}