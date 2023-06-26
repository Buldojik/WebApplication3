using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class LaborCostsHandler : ILaborCostsHandler
    {
        private readonly ConnectionContext _context;
        private readonly IMapper _mapper;
        public LaborCostsHandler(ConnectionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LaborCostsResponse> Create(CreateLaborCostsReqest request)
        {
            var newLaborCosts = _mapper.Map<CreateLaborCostsReqest, LaborCosts>(request);
            _context.Add(newLaborCosts);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<LaborCosts, LaborCostsResponse>(newLaborCosts);
            return result;
        }

        public async Task<LaborCostsResponse> Delete(int id)
        {
            var laborCosts = await _context.LaborCosts.FirstOrDefaultAsync(p => p.ID == id);
            var result = _mapper.Map<LaborCosts, LaborCostsResponse>(laborCosts);
            _context.LaborCosts.Remove(laborCosts);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<LaborCostsResponse> GetByID(int id)
        {
            var quest = await _context.LaborCosts.FirstOrDefaultAsync(p => p.ID == id);
            var result = _mapper.Map<LaborCosts, LaborCostsResponse>(quest);
            return result;
        }

        public async Task<LaborCostsResponse> Update(int id, UpdateLaborCostsReqest request)
        {
            var quest = await _context.LaborCosts.FirstOrDefaultAsync(p => p.ID == id);
            _mapper.Map(request, quest);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<LaborCosts, LaborCostsResponse>(quest);
            return result;
        }
    }
}
