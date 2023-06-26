using System.Threading.Tasks;

namespace WebApplication3.Interfaces
{
    public interface IProjectHandler
    {
        Task<ProjectResponse> GetByID(int id);
        /// <summary>
        /// Создает сущность 
        /// </summary>
        /// <param name="request">Запрос на создание</param>
        /// <returns></returns>
        Task<ProjectResponse> Create(CreateProjectReqest request);
        Task<ProjectResponse> Update(int id, UpdateProjectReqest request);
        Task<ProjectResponse> Delete(int id);
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

