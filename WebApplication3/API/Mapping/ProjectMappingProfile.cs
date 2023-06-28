using AutoMapper;
using WebApplication3.DataBase.Models;
using WebApplication3.Interfaces;

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
