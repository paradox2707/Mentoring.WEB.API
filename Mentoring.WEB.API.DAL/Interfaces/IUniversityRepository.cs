﻿using Mentoring.WEB.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IUniversityRepository
    {
        Task<List<University>> GetAllAsync();
        Task<List<University>> GetAllWithSpecialiesAsync();
        Task<List<University>> GetAllByAsync(Expression<Func<University, bool>> expression);
    }
}
