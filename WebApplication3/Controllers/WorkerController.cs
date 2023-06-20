using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("/api/[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly ConnectionContext _dataBase;

        public WorkerController(ConnectionContext dataBase)
        {
            _dataBase = dataBase;
        }
        /// <summary>
        /// Получает данные сущности     
        /// </summary>
        [HttpGet]
        public IEnumerable<Worker> Get() => _dataBase.Set<Worker>();
        /// <summary>
        /// Получает данные сущности по ID     
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetID(int id)
        {
            var worker = await _dataBase.Set<Worker>().FirstOrDefaultAsync(p => p.ID == id);
            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }
        /// <summary>
        /// Удаляет данные сущности по ID      
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _dataBase.Worker.Remove(await _dataBase.Worker.FindAsync(id));
            await _dataBase.SaveChangesAsync();
            return Ok(new { Message = "Deleted" });
        }
        /// <summary>
        /// Заполняет сущность
        /// </summary>
        /// <param name="workers"></param>
        /// <returns>A newly created Worker</returns>
        /// <remarks>
        /// Запрос на создание сущности:
        ///
        ///     POST /Worker
        ///     {
        ///        "ID": 1
        ///        "Number": "12289"
        ///        "Name": "Петров Петр Петрович",
        ///        "Cod1C": "hfjhfkdshfkjsdh"
        ///        "Post": "dfgdfgdfgdf"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Возвращает созданый элемент</response>
        /// <response code="400">Ошибки валидации</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Worker workers)
        {
            _dataBase.Add(workers);
            await _dataBase.SaveChangesAsync();
            return CreatedAtAction(nameof(GetID), new { id = workers.ID }, workers);
        }
        /// <summary>
        /// Редактирует данные сущности
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(Worker workers)
        {
            _dataBase.Entry(workers).State = EntityState.Modified;
            await _dataBase.SaveChangesAsync();
            return Ok(new { Message = "Update" });

        }
    }
}
