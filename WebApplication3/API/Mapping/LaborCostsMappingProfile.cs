using AutoMapper;
using WebApplication3.DataBase.Models;
using WebApplication3.Interfaces;

namespace WebApplication3.Mapping
{
    public class LaborCostsMappingProfile:Profile
    {
        public LaborCostsMappingProfile()
        {
            CreateMap<CreateLaborCostsReqest, LaborCosts>();
            CreateMap<LaborCosts, LaborCostsResponse>();
            CreateMap<UpdateLaborCostsReqest, LaborCosts>();
        }
    }
}
