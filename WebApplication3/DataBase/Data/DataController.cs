using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication3.Interfaces;
using WebApplication3.Repository;

namespace WebApplication3.Data
{
    [Route("/api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataHandler _dataHandler;
        public DataController(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create()
        {
            await _dataHandler.CreateDataWorker();
            await _dataHandler.CreateDataProject();
            await _dataHandler.CreateDataQuest();
            await _dataHandler.CreateDataDivision();
            await _dataHandler.CreateDataLaborCosts();
            return Ok();
        }
    }
}
