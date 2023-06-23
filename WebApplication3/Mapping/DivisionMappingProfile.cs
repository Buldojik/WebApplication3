using AutoMapper;
using System;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Mapping
{
    public class DivisionMappingProfile:Profile
    {
        public DivisionMappingProfile()
        {
            CreateMap<Division, CreateDivisionReqest>();
            CreateMap<DivisionResponse, Division>();
        }
    }
}
