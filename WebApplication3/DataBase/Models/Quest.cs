using System.Collections.Generic;

namespace WebApplication3.Models
{
    /// <summary>
    /// Задача
    /// </summary>
    public class Quest
    {
        public int ID { get; set; }
        /// <summary>
        /// Наименование задачи
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ссылка на проэкт
        /// </summary>
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        /// <summary>
        /// коллекция ссылок на сотрудника
        /// </summary>
        public List<int> WorkersID { get; set; }
        public List<Worker> Workers { get; set; }
    }
    public class CreateQuestReqest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public List<int> WorkersID { get; set; }

    }
    /// <summary>
    /// Ответ сущности Quest
    /// </summary>
    public class QuestResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public List<int> WorkersID { get; set; }
    }
    /// <summary>
    /// Запрос на обновление сущности Quest
    /// </summary>
    public class UpdateQuestReqest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public List<int> WorkersID { get; set; }
    }
}
