using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("/api/[controller]")]
    public class DivisionController : ControllerBase
    {
        private readonly ConnectionContext _dataBase;

        public DivisionController(ConnectionContext dataBase)
        {
            _dataBase = dataBase;
        }
        /// <summary>
        /// Получает данные сущности     
        /// </summary>
        [HttpGet]
        public IEnumerable<Division> Get() => _dataBase.Set<Division>();
        /// <summary>
        /// Получает данные сущности по ID     
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetID(int id)
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
        public async Task<IActionResult> Delete(int id)
        {
            _dataBase.Remove(await _dataBase.Set<Division>().FirstOrDefaultAsync(p => p.ID == id));
            return Ok(new { Message = "Deleted" });
        }
        /// <summary>
        /// Заполняет сущность
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(Division divisions)
        {
            _dataBase.Add(divisions);
            await _dataBase.SaveChangesAsync();
            return CreatedAtAction(nameof(GetID), new { id = divisions.ID }, divisions);
        }
    }
}
