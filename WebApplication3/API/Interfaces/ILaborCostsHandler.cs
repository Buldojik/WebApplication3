using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface ILaborCostsHandler
    {
        Task<LaborCostsResponse> GetByID(int id);
        /// <summary>
        /// Создает сущность 
        /// </summary>
        /// <param name="request">Запрос на создание</param>
        /// <returns></returns>
        Task<LaborCostsResponse> Create(CreateLaborCostsReqest request);
        Task<LaborCostsResponse> Update(int id, UpdateLaborCostsReqest request);
        Task<LaborCostsResponse> Delete(int id);
    }
    
}
