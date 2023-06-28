using AutoMapper;
using System;
using WebApplication3.DataBase.Models;
using WebApplication3.Interfaces;

namespace WebApplication3.Mapping
{
    public class DivisionMappingProfile:Profile
    {
        public DivisionMappingProfile()
        {
            CreateMap<CreateDivisionReqest,Division >();
            CreateMap<Division, DivisionResponse > ();
            CreateMap<UpdateDivisionReqest, Division> ();
        }
    }
}
