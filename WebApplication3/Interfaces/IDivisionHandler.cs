using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IDivisionHandler
    {
        Task<CreateDivisionReqest> GetByID(int id);
        /// <summary>
        /// Создает сущность 
        /// </summary>
        /// <param name="division">Запрос на создание</param>
        /// <returns></returns>
        Task<DivisionResponse> Create(CreateDivisionReqest division);
        Task<Division> Update(DivisionResponse division);
        Task<DivisionResponse> Delete(int i);

    }
    public class CreateDivisionReqest
    {
        public string Name { get; set; }
        public int WorkerID { get; set; }
    }
    public class DivisionResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int WorkerID { get; set; }
    }
}
