namespace WebApplication3.Models
{
    /// <summary>
    /// Проект
    /// </summary>
    public class Project
    {
        public int ID { get; set; }
        /// <summary>
        /// Наименование проэкта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ссылка на сотрудника
        /// </summary>
        public int WorkerID { get; set; }
        public Worker Worker { get; set; }
    }
    /// <summary>
    /// Запрос на создание сущности Projec
    /// </summary>
    public class CreateProjectReqest
    {
        public string Name { get; set; }
        public int WorkerID { get; set; }
    }
    /// <summary>
    /// Ответ сущности Projec
    /// </summary>
    public class ProjectResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int WorkerID { get; set; }
    }
    /// <summary>
    /// Запрос на обновление сущности Projec
    /// </summary>
    public class UpdateProjectReqest
    {
        public string Name { get; set; }
        public int WorkerID { get; set; }
    }
}
