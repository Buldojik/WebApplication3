using AutoMapper;
using WebApplication3.DataBase.Models;
using WebApplication3.Interfaces;

namespace WebApplication3.Mapping
{
    public class WorkerMapingProfile:Profile
    {
        public WorkerMapingProfile()
        {
            CreateMap<CreateWorkerReqest, Worker>();
            CreateMap<Worker, WorkerResponse>();
            CreateMap<UpdateWorkerReqest, Worker>();
        }
    }
}
