using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    /// <summary>
    /// Подразделение
    /// </summary>
    public class Division
    {
        
        public int ID { get; set; }
        /// <summary>
        /// Наименование отдела
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ссылка на сотрудника
        /// </summary>
        public int WorkerID { get; set; }
        public Worker Worker { get; set; }
    }
    /// <summary>
    /// Запрос на создание сущности Division
    /// </summary>
    public class CreateDivisionReqest
    {
        /// <summary>
        /// Наименование отдела
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ссылка на сотрудника
        /// </summary>
        public int WorkerID { get; set; }

    }
    /// <summary>
    /// Ответ сущности Division
    /// </summary>
    public class DivisionResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int WorkerID { get; set; }
    }
    /// <summary>
    /// Запрос на обновление сущности Division
    /// </summary>
    public class UpdateDivisionReqest
    {
        public string Name { get; set; }
        public int WorkerID { get; set; }
    }
}
