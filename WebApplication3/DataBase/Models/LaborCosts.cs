using System;

namespace WebApplication3.Models
{
    /// <summary>
    /// Трудозатраты
    /// </summary>
    public class LaborCosts
    {
        public int ID { get; set; }
        /// <summary>
        /// Ссылка на задачу
        /// </summary>
        public int QuestID { get; set; }
        public Quest Quest { get; set; }
        /// <summary>
        /// Ссылка на рабочего
        /// </summary>
        public int WorkerID { get; set; }
        public Worker Worker { get; set; }
        /// <summary>
        /// Дата выполнения
        /// </summary>
        public DateOnly Date { get; set; }
        /// <summary>
        /// Количество часов
        /// </summary>
        public float Hour { get; set; }
    }
    /// <summary>
    /// Запрос на создание сущности LaborCosts
    /// </summary>
    public class CreateLaborCostsReqest
    {
        public int QuestID { get; set; }
        public int WorkerID { get; set; }
        public DateOnly Date { get; set; }
        public float Hour { get; set; }
    }
    /// <summary>
    /// Ответ сущности LaborCosts
    /// </summary>
    public class LaborCostsResponse
    {
        public int id { get; set; }
        public int QuestID { get; set; }
        public int WorkerID { get; set; }
        public DateOnly Date { get; set; }
        public float Hour { get; set; }
    }
    /// <summary>
    /// Запрос на обновление сущности LaborCosts
    /// </summary>
    public class UpdateLaborCostsReqest
    {
        public int QuestID { get; set; }
        public int WorkerID { get; set; }
        public DateOnly Date { get; set; }
        public float Hour { get; set; }
    }
}
