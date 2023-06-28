using AutoMapper;
using WebApplication3.Models;

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
