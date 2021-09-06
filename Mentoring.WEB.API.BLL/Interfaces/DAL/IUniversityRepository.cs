using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.Common.FilterModels;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Filters;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces.DAL
{
    public interface IUniversityRepository
    {
        Task<List<UniversityModel>> GetAllAsync();
        Task<List<UniversityModel>> GetAllWithSpecialiesAsync();
        Task<List<UniversityModel>> GetAllByAsync(Expression<Func<UniversityModel, bool>> expression);
        Task<List<UniversityModel>> GetAllBySql(UniversityFilter filter);
        Task<List<UniversityModel>> GetAllForUserApplicationBySql(UniversityFilterForUserApplication filter);
        Task<List<UniversityModel>> GetAllForUserApplicationValidationBySql(UserApplicationModel filter);
    }
}
