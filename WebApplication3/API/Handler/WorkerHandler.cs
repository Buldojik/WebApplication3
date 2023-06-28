using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication3.API.Interfaces;
using WebApplication3.DataBase.Connection;
using WebApplication3.DataBase.Models;

namespace WebApplication3.Repository
{
    public class WorkerHandler:IWorkerHandler
    {
        private readonly ConnectionContext _context;
        private readonly IMapper _mapper;
        public WorkerHandler(ConnectionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkerResponse> Create(CreateWorkerReqest request)
        {
            var newWorker = _mapper.Map<CreateWorkerReqest, Worker>(request);
            _context.Add(newWorker);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Worker, WorkerResponse>(newWorker);
            return result;
        }

        public async Task<WorkerResponse> Delete(int id)
        {
            var worker = await _context.Worker.FirstOrDefaultAsync(p => p.ID == id);
            var result = _mapper.Map<Worker, WorkerResponse>(worker);
            _context.Worker.Remove(worker);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<WorkerResponse> GetByID(int id)
        {
            var worker = await _context.Worker.FirstOrDefaultAsync(p => p.ID == id);
            var result = _mapper.Map<Worker, WorkerResponse>(worker);
            return result;
        }

        public async Task<WorkerResponse> Update(int id, UpdateWorkerReqest request)
        {
            var worker = await _context.Worker.FirstOrDefaultAsync(p => p.ID == id);
            _mapper.Map(request, worker);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Worker, WorkerResponse>(worker);
            return result;
        }
    }
}
