using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication3.DataBase.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("/api/[controller]")]
    public class LaborCostsController : ControllerBase
    {
        private readonly ConnectionContext _dataBase;
        private readonly ILaborCostsHandler _laborCostsHandler;

        public LaborCostsController(ConnectionContext dataBase, ILaborCostsHandler laborCostsHandler)
        {
            _dataBase = dataBase;
            _laborCostsHandler = laborCostsHandler;
        }
        /// <summary>
        /// Получает данные сущности по ID     
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetID(int id)
        {
            var worker = await _laborCostsHandler.GetByID(id);
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
            return Ok(await _laborCostsHandler.Delete(id));
        }
        /// <summary>
        /// Создает сущность
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns>A newly created LaborCosts</returns>
        /// <remarks>
        /// Запрос на создание сущности:
        ///
        ///     POST /LaborCosts
        ///     {
        ///        "Name": "Петров Петр Петрович",
        ///        "QuestID" : 1,
        ///        "WorkerID": 1,
        ///        "Date": 12.01.2023,
        ///        "Hour": 8.30
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Возвращает созданый элемент</response>
        /// <response code="400">Ошибки валидации</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LaborCostsResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateLaborCostsReqest reqest)
        {
            return Ok(await _laborCostsHandler.Create(reqest));
        }
        /// <summary>
        /// Редактирует данные сущности
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateLaborCostsReqest request)
        {
            return Ok(await _laborCostsHandler.Update(id, request));

        }
    }
}
