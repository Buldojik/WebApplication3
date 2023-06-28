using AutoMapper;
using WebApplication3.DataBase.Models;
using WebApplication3.Interfaces;
using static WebApplication3.Interfaces.IQuestHandler;

namespace WebApplication3.Mapping
{
    public class QuestMappingProfile:Profile
    {
        public QuestMappingProfile()
        {
            CreateMap<CreateQuestReqest, Quest>();
            CreateMap<Quest, QuestResponse>();
            CreateMap<UpdateQuestReqest, Quest>();
        }
    }
}
