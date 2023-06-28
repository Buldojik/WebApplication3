using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class DataHandler : IDataHandler
    {
        private readonly ConnectionContext _context;
        private readonly IMapper _mapper;
        public DataHandler(ConnectionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateDataDivision()
        {
            var divisionRequest = new Division();
            List<Division> division = new List<Division> { new Division { ID = 1, Name = "name", WorkerID = 1 } };
            _mapper.Map(division, divisionRequest);
            _context.Division.Add(divisionRequest);
            await _context.SaveChangesAsync();
        }

        public async Task CreateDataLaborCosts()
        {
            var laborCostsRequest = new LaborCosts();
            var laborCosts = new List<LaborCosts> { new LaborCosts { ID = 1, QuestID = 1, WorkerID = 1 } };
            _mapper.Map(laborCosts, laborCostsRequest);
            _context.LaborCosts.Add(laborCostsRequest);
            await _context.SaveChangesAsync();
        }

        public async Task CreateDataProject()
        {
            var projectRequest = new Project();
            List<Project> project = new List<Project> { new Project { ID = 1, Name = "name", WorkerID = 2 } };
            _mapper.Map(project, projectRequest);
            _context.Project.Add(projectRequest);
            await _context.SaveChangesAsync();
        }

        public async Task CreateDataQuest()
        {
            var questRequest = new Quest();
            List<Quest> quest = new List<Quest> { new Quest { ID = 1, Name = "name", Description ="description", ProjectID = 1, WorkersID = {1,2 } } };
            _mapper.Map(quest, questRequest);
            _context.Quest.Add(questRequest);
            await _context.SaveChangesAsync();
        }

        public async Task CreateDataWorker()
        {
            var workerRequest = new Worker();
            var worker = new List<Worker> { new Worker { ID = 1, Name = "name", Post = "post" } };
            _mapper.Map(worker, workerRequest);
            _context.Worker.Add(workerRequest);
            await _context.SaveChangesAsync();
        }
    }
}
