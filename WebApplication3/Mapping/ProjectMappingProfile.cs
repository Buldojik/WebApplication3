using AutoMapper;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Mapping
{
    public class ProjectMappingProfile:Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<CreateProjectReqest, Project>();
            CreateMap<Project, ProjectResponse>();
            CreateMap<UpdateProjectReqest, Project>();
        }
    }
}
