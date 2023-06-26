using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using static WebApplication3.Interfaces.IQuestHandler;

namespace WebApplication3.Controllers
{
    [Route("/api/[controller]")]
    public class QuestController : ControllerBase
    {
        private readonly ConnectionContext _dataBase;
        private readonly IQuestHandler _questHandler;

        public QuestController(ConnectionContext dataBase, IQuestHandler questHandler)
        {
            _dataBase = dataBase;
            _questHandler = questHandler;
        }
        /// <summary>
        /// Получает данные сущности     
        /// </summary>
        [HttpGet]
        public IEnumerable<Quest> Get() => _dataBase.Set<Quest>();
        /// <summary>
        /// Получает данные сущности по ID     
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetID(int id)
        {
            var quest = await _questHandler.GetByID(id);
            if (quest == null)
            {
                return NotFound();
            }

            return Ok(quest);
        }
        /// <summary>
        /// Удаляет данные сущности по ID      
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _questHandler.Delete(id));
        }
        /// <summary>
        /// Создает сущность
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns>A newly created Quest</returns>
        /// <remarks>
        /// Запрос на создание сущности:
        ///
        ///     POST /Quest
        ///     {
        ///        "Name": "Петров Петр Петрович",
        ///        "ProjectID": 1,
        ///        "WokersID": 1 2 3,
        ///        "Description": "dfgdfgdfgdf"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Возвращает созданый элемент</response>
        /// <response code="400">Ошибки валидации</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(QuestResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateQuestReqest reqest)
        {
            return Ok(await _questHandler.Create(reqest));
        }
        /// <summary>
        /// Редактирует данные сущности
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateQuestReqest request)
        {
            return Ok(await _questHandler.Update(id, request));

        }
    }
}
