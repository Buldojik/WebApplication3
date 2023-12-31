﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IQuestHandler
    {
        Task<QuestResponse> GetByID(int id);
        /// <summary>
        /// Создает сущность 
        /// </summary>
        /// <param name="quest">Запрос на создание</param>
        /// <returns></returns>
        Task<QuestResponse> Create(CreateQuestReqest request);
        Task<QuestResponse> Update(int id, UpdateQuestReqest request);
        Task<QuestResponse> Delete(int id);
        /// <summary>
        /// Запрос на создание сущности Quest
        /// </summary>
        
    }
}
