using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication3.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using static WebApplication3.Interfaces.IQuestHandler;

namespace WebApplication3.Repository
{
    public class ProjectHandler : IProjectHandler
    {
        private readonly ConnectionContext _context;
        private readonly IMapper _mapper;
        public ProjectHandler(ConnectionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProjectResponse> Create(CreateProjectReqest request)
        {
            var newProject = _mapper.Map<CreateProjectReqest, Project>(request);
            _context.Add(newProject);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Project, ProjectResponse>(newProject);
            return result;
        }

        public async Task<ProjectResponse> Delete(int id)
        {
            var project = await _context.Project.FirstOrDefaultAsync(p => p.ID == id);
            var result = _mapper.Map<Project, ProjectResponse>(project);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<ProjectResponse> GetByID(int id)
        {
            var quest = await _context.Project.FirstOrDefaultAsync(p => p.ID == id);
            var result = _mapper.Map<Project, ProjectResponse>(quest);
            return result;
        }

        public async Task<ProjectResponse> Update(int id, UpdateProjectReqest request)
        {
            var quest = await _context.Project.FirstOrDefaultAsync(p => p.ID == id);
            _mapper.Map(request, quest);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Project, ProjectResponse>(quest);
            return result;
        }
    }
}
