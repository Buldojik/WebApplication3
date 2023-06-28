using AutoMapper;
using System.Collections.Generic;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class DataMapperProfile:Profile
    {
        public DataMapperProfile()
        {
            CreateMap<List<Worker>, Worker>();
            CreateMap<List<LaborCosts>, LaborCosts>();
            CreateMap<List<Division>, Division>();
            CreateMap<List<Project>, Project>();
            CreateMap<List<Quest>, Quest>();
        }
    }
}
