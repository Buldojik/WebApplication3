namespace WebApplication3.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Worker
    {
        public int ID { get; set; }
        /// <summary>
        /// ФИО рабочего
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Номер рабочего
        /// </summary>
        public string Number { get; set; }
        public string Cod1C { get; set; }
        /// <summary>
        /// Должность рабочего
        /// </summary>
        public string Post { get; set; }
    }
    /// <summary>
    /// Запрос на создание сущности Worker
    /// </summary>
    public class CreateWorkerReqest
    {
        public string Name { get; set; }
        public string Post { get; set; }
    }
    /// <summary>
    /// Ответ сущности Worker
    /// </summary>
    public class WorkerResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
    }
    /// <summary>
    /// Запрос на обновление сущности Worker
    /// </summary>
    public class UpdateWorkerReqest
    {
        public string Name { get; set; }
        public string Post { get; set; }
    }
}
