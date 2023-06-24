using System.Threading.Tasks;

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
    public class CreateWorkerReqest
    {
        public string Name { get; set; }
        public string Post { get; set; }
    }
    public class WorkerResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
    }
    public class UpdateWorkerReqest
    {
        public string Name { get; set; }
        public string Post { get; set; }
    }
}
