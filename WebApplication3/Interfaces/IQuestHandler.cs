using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication3.Interfaces
{
    public interface IQuestHandler
    {
        Task<QuestResponse> GetByID(int id);
        /// <summary>
        /// Создает сущность 
        /// </summary>
        /// <param name="quest">Запрос на создание</param>
        /// <returns></returns>
        Task<QuestResponse> Create(CreateQuestReqest request);
        Task<QuestResponse> Update(int id, UpdateQuestReqest request);
        Task<QuestResponse> Delete(int id);
        /// <summary>
        /// Запрос на создание сущности Quest
        /// </summary>
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
            //public List<Worker> workers { get; set; }
        }
    }
}
