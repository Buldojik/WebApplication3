using System;
using System.Threading.Tasks;

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
    public class CreateLaborCostsReqest
    {
        public int QuestID { get; set; }
        public int WorkerID { get; set; }
        public DateOnly Date { get; set; }
        public float Hour { get; set; }
    }
    public class LaborCostsResponse
    {
        public int id { get; set; }
        public int QuestID { get; set; }
        public int WorkerID { get; set; }
        public DateOnly Date { get; set; }
        public float Hour { get; set; }
    }
    public class UpdateLaborCostsReqest
    {
        public int QuestID { get; set; }
        public int WorkerID { get; set; }
        public DateOnly Date { get; set; }
        public float Hour { get; set; }
    }
}
