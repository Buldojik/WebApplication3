using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using Task = System.Threading.Tasks.Task;

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
            var result = new DivisionResponse { id = newDivision.ID,};
            return result;
        }

        public async Task<CreateDivisionReqest> GetByID(int id)
        {
            CreateDivisionReqest division;
            var result = await _context.Division.SingleOrDefaultAsync(p => p.ID == id);
            division = _mapper.Map<Division, CreateDivisionReqest>(result);
            return division;
        }

        public async Task<Division> Update(DivisionResponse request)
        {
            //var result = await _context.Division.SingleOrDefaultAsync(p => p.ID == id);
            var division = _mapper.Map<DivisionResponse, Division>(request);
            _context.Entry(division).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return division;
        }
    }
}
