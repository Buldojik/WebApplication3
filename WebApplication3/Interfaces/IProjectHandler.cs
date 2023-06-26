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
    public class CreateProjectReqest
    {
        public string Name { get; set; }
        public int WorkerID { get; set; }
    }
    public class ProjectResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int WorkerID { get; set; }
    }
    public class UpdateProjectReqest
    {
        public string Name { get; set; }
        public int WorkerID { get; set; }
    }
}

