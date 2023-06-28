using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication3.DataBase.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class QuestHandler : IQuestHandler
    {
        private readonly ConnectionContext _context;
        private readonly IMapper _mapper;
        public QuestHandler(ConnectionContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }
        public async Task<QuestResponse> Create(CreateQuestReqest request)
        {
            var newQuest = _mapper.Map<CreateQuestReqest, Quest>(request);
            _context.Add(newQuest);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Quest, QuestResponse>(newQuest);
            return result;
        }

        public async Task<QuestResponse> Delete(int id)
        {
            var quest = await _context.Quest.FirstOrDefaultAsync(p => p.ID == id);
            var result = _mapper.Map<Quest, QuestResponse>(quest);
            _context.Quest.Remove(quest);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<QuestResponse> GetByID(int id)
        {
            var quest = await _context.Quest.FirstOrDefaultAsync(p => p.ID == id);
            var result = _mapper.Map<Quest, QuestResponse>(quest);
            return result;
        }

        public async Task<QuestResponse> Update(int id, UpdateQuestReqest request)
        {
            var quest = await _context.Quest.FirstOrDefaultAsync(p => p.ID == id);
            _mapper.Map(request, quest);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Quest, QuestResponse>(quest);
            return result;
        }
    }
}
