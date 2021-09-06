using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.Common.FilterModels;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces.DAL
{
    public interface IUserApplicationRepository
    {
        Task<List<UserApplicationModel>> GetAllAsync();
        Task<List<UserApplicationModel>> GetAllBySql(UserApplicationFilter filter);
        Task CreateAsync(UserApplicationModel entity);
    }
}
