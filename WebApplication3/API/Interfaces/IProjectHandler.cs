using System.Threading.Tasks;
using WebApplication3.Models;

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
}

