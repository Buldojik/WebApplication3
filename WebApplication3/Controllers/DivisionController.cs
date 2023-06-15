using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("/api/[controller]")]
    public class DivisionController : ControllerBase
    {
        //private List<Division> divisions = new List<Division>(new[] {
        //    new Division{ ID = 1, Director = "fdsfdfs", Name = "dasdas" },
        //    new Division{ ID = 2, Director = "Pavc", Name = "kontr" },
        //    new Division{ ID = 3, Director = "Pavc", Name = "kontr" }
        //});

        private readonly ConnectionContext _dataBase;

        public DivisionController(ConnectionContext dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        public IEnumerable<Division> Get() => _dataBase.Set<Division>();

        [HttpGet("{id}")]
        public async Task <IActionResult> GetID(int id)
        {
            var division = await _dataBase.Set<Division>().FirstOrDefaultAsync(p => p.ID == id);
            if (division == null)
            {
                return NotFound();
            }

            return Ok(division);
        }
        /// <summary>
        /// Удаляет данные сущности по ID      
        /// </summary>
        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            _dataBase.Remove(await _dataBase.Set<Division>().FirstOrDefaultAsync(p => p.ID == id));
            return Ok(new { Message = "Deleted" });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Division divisions)
        {
            _dataBase.Add(divisions);
            await _dataBase.SaveChangesAsync();
            return CreatedAtAction(nameof(GetID), new {id = divisions.ID}, divisions);
        }
        
        //private int NextId => divisions.Count() == 0 ? 1 : divisions.Max(x => x.ID) + 1;

        //[HttpPost]
        //public IActionResult Post(Division division)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    division.ID = NextId;
        //    divisions.Add(division);
        //    return CreatedAtAction(nameof(Get), new { id = division.ID }, division);
        //}
        //[HttpPost("AddDivision")]
        //public IActionResult PostBody([FromBody] Division division) => Post(division);
    }
}
