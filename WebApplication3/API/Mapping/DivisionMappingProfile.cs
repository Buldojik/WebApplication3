using AutoMapper;
using WebApplication3.Interfaces;
using WebApplication3.Models;

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
