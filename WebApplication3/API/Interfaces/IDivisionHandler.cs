﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IDivisionHandler
    {
        Task<DivisionResponse> GetByID(int id);
        /// <summary>
        /// Создает сущность 
        /// </summary>
        /// <param name="division">Запрос на создание</param>
        /// <returns></returns>
        Task<DivisionResponse> Create(CreateDivisionReqest division);
        Task<DivisionResponse> Update(int id,UpdateDivisionReqest division);
        Task<DivisionResponse> Delete(int i);

    }
    
}
