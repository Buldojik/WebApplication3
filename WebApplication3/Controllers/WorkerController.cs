using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("/api/[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly ConnectionContext _dataBase;
        private readonly IWorkerHandler _workerHandler;

        public WorkerController(ConnectionContext dataBase, IWorkerHandler workerHandler)
        {
            _dataBase = dataBase;
            _workerHandler = workerHandler;
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
            var worker = await _workerHandler.GetByID(id);
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
            return Ok(await _workerHandler.Delete(id));
        }
        /// <summary>
        /// Заполняет сущность
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns>A newly created Worker</returns>
        /// <remarks>
        /// Запрос на создание сущности:
        ///
        ///     POST /Worker
        ///     {
        ///        "Name": "Петров Петр Петрович",
        ///        "Post": "dfgdfgdfgdf"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Возвращает созданый элемент</response>
        /// <response code="400">Ошибки валидации</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WorkerResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateWorkerReqest reqest)
        {
            return Ok(await _workerHandler.Create(reqest));
        }
        /// <summary>
        /// Редактирует данные сущности
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateWorkerReqest request)
        {
            return Ok(await _workerHandler.Update(id, request));

        }
    }
}
