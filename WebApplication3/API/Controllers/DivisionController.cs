using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Interfaces;

namespace WebApplication3.Controllers
{
    [Route("/api/[controller]")]
    public class DivisionController : ControllerBase
    {
        private readonly IDivisionHandler _divisioHandler;

        public DivisionController( IDivisionHandler divisionRepository)
        {
            _divisioHandler = divisionRepository;
        }
        
        /// <summary>
        /// Создает сущность
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns>A newly created Division</returns>
        /// <remarks>
        /// Запрос на создание сущности:
        ///
        ///     POST /Division
        ///     {
        ///        "ID": 1
        ///        "Name": "Item #1",
        ///        "Director": ID Worker
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Возвращает созданый элемент</response>
        /// <response code="400">Ошибки валидации</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DivisionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateDivisionReqest reqest)
        {
            return Ok(await _divisioHandler.Create(reqest));
        }
        
        /// <summary>
        /// Получает данные сущности по ID     
        /// </summary>
        /// <returns>A newly GetID Division</returns>
        /// <response code="201">Возвращает запрошенный элемент</response>
        /// <response code="400">Ошибка валидации</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetID(int id)
        {
            var division = await _divisioHandler.GetByID(id);
            if (division == null)
            {
                return NotFound();
            }

            return Ok(division);
        }
        /// <summary>
        /// Удаляет данные сущности по ID      
        /// </summary>
        /// <returns>A newly delete Division</returns>
        /// <response code="201">Возвращает сообщение об удалении</response>
        /// <response code="400">Ошибка валидации</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _divisioHandler.Delete(id));
        }
        /// <summary>
        /// Редактирует данные сущности
        /// </summary>
        /// <response code = "201" > Возвращает обновленный элемент</response>
        /// <response code = "400" > Ошибки валидации</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id,UpdateDivisionReqest reqest)
        {
            return Ok(await _divisioHandler.Update(id,reqest));

        }
    }
}
