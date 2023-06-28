using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using static WebApplication3.Interfaces.IQuestHandler;

namespace WebApplication3.Data
{
    public interface IDataHandler
    {
        Task CreateDataDivision();
        Task CreateDataLaborCosts();
        Task CreateDataProject();
        Task CreateDataQuest();
        Task CreateDataWorker();
    }
}
