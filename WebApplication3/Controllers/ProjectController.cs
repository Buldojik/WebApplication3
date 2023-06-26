using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("/api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ConnectionContext _dataBase;
        private readonly IProjectHandler _projectHandler;

        public ProjectController(ConnectionContext dataBase, IProjectHandler projectHandler)
        {
            _dataBase = dataBase;
            _projectHandler = projectHandler;
        }
        /// <summary>
        /// Получает данные сущности по ID     
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetID(int id)
        {
            var worker = await _projectHandler.GetByID(id);
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
            return Ok(await _projectHandler.Delete(id));
        }
        /// <summary>
        /// Создает сущность
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns>A newly created Project</returns>
        /// <remarks>
        /// Запрос на создание сущности:
        ///
        ///     POST /Project
        ///     {
        ///        "Name": "Петров Петр Петрович",
        ///        "WorkerID": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Возвращает созданый элемент</response>
        /// <response code="400">Ошибки валидации</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProjectResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateProjectReqest reqest)
        {
            return Ok(await _projectHandler.Create(reqest));
        }
        /// <summary>
        /// Редактирует данные сущности
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateProjectReqest request)
        {
            return Ok(await _projectHandler.Update(id, request));

        }
    }
}
