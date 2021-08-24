using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IUserApplicationRepository
    {
        Task<List<UserApplication>> GetAllAsync();
        Task<List<UserApplication>> GetAllBySql(UserApplicationFilterInSql filter);
        Task CreateAsync(UserApplication entity);
    }
}
