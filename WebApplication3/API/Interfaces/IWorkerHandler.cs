using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IWorkerHandler
    {
        Task<WorkerResponse> GetByID(int id);
        /// <summary>
        /// Создает сущность 
        /// </summary>
        /// <param name="request">Запрос на создание</param>
        /// <returns></returns>
        Task<WorkerResponse> Create(CreateWorkerReqest request);
        Task<WorkerResponse> Update(int id, UpdateWorkerReqest request);
        Task<WorkerResponse> Delete(int id);
    }
    
}
