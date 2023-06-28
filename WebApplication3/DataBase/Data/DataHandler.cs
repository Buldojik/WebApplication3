using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.DataBase.Connection;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class DataHandler: IDataHandler
    {
        private readonly ConnectionContext _context;
        public DataHandler(ConnectionContext context)
        {
            _context = context;
        }
        public async Task CreateDataDivision()
        {
            
            _context.Division.Add(new Division { ID = 100, Name = "name", WorkerID = 100});
            await _context.SaveChangesAsync();
        }

        public async Task CreateDataLaborCosts()
        {

            _context.LaborCosts.Add(new LaborCosts { ID = 100, Hour = 8 , QuestID = 100, WorkerID = 100});
            await _context.SaveChangesAsync();
        }

        public async Task CreateDataProject()
        {

            _context.Project.Add(new Project { ID = 100, Name = "name", WorkerID = 100 });
            await _context.SaveChangesAsync();
        }

        public async Task CreateDataQuest()
        {

            _context.Quest.Add(new Quest { ID = 100, Name = "name", Description = "description", ProjectID = 100, WorkersID = new List<int>{100,101} });
            await _context.SaveChangesAsync();
        }

        public async Task CreateDataWorker()
        {
            _context.Worker.Add(new Worker { ID = 100, Name = "name", Post = "post" });
            _context.Worker.Add(new Worker { ID = 101, Name = "cxz", Post = "cxz" });
            await _context.SaveChangesAsync();
        }
    }
}
