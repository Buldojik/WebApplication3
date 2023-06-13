using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("/api/[controller]")]
    public class DivisionController : Controller
    {
        private List<Division> divisions = new List<Division>(new[] {
            new Division{ ID = 1, Director = "fdsfdfs", Name = "dasdas" },
            new Division{ ID = 2, Director = "Pavc", Name = "kontr" },
            new Division{ ID = 3, Director = "Pavc", Name = "kontr" }
        });

        [HttpGet]
        public IEnumerable<Division> Get() => divisions;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var division = divisions.SingleOrDefault(p => p.ID == id);
            if (division == null)
            {
                return NotFound();
            }

            return Ok(division);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            divisions.Remove(divisions.SingleOrDefault(p => p.ID == id));
            return Ok(new { Message = "Deleted" });
        }

        private int NextId => divisions.Count() == 0 ? 1 : divisions.Max(x => x.ID) + 1;

        [HttpPost]
        public IActionResult Post(Division division)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            division.ID = NextId;
            divisions.Add(division);
            return CreatedAtAction(nameof(Get), new { id = division.ID }, division);
        }
        [HttpPost("AddDivision")]
        public IActionResult PostBody([FromBody] Division division) => Post(division);
    }
}
