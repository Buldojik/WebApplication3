using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication3.DataBase.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Обработчик CRUD <inheritdoc cref="Division"/>
    /// </summary>
    public class DivisionHandler : IDivisionHandler
    {
        private readonly ConnectionContext _context;
        private readonly IMapper _mapper;
        public DivisionHandler(ConnectionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<DivisionResponse> Create(CreateDivisionReqest request)
        {
            var newDivision = new Division();
            newDivision.Name = request.Name;
            newDivision.WorkerID = request.WorkerID;
            _context.Add(newDivision);
            await _context.SaveChangesAsync();
            var result = new DivisionResponse { id = newDivision.ID, Name = newDivision.Name, WorkerID = newDivision.WorkerID };
            return result;
        }//_mapper.Map<DivisionResponse>(newDivision); 

        public async Task<DivisionResponse> Delete(int id)
        {
            var newDivision = new Division();
            newDivision.ID = id;
            _context.Division.Remove(newDivision);
            await _context.SaveChangesAsync();
            var result = new DivisionResponse { id = newDivision.ID, Name = newDivision.Name, WorkerID = newDivision.WorkerID };
            return result;
        }

        public async Task<DivisionResponse> GetByID(int id)
        {
            var division = await _context.Division.FirstOrDefaultAsync(p => p.ID == id);
            var result = _mapper.Map<Division, DivisionResponse>(division);
            return result;
        }

        public async Task<DivisionResponse> Update(int id, UpdateDivisionReqest request)
        {
            var division = await _context.Division.FirstOrDefaultAsync(p => p.ID == id);
            _mapper.Map(request,division);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Division, DivisionResponse>(division);
            return result;
        }
    }
}
