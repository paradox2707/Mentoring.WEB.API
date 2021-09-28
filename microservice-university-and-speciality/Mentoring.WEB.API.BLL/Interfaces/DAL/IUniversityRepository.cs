using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.FilterModels;
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
        Task<List<UniversityModel>> GetAllBySql(UniversityFilter filter);
        Task<List<UniversityModel>> GetAllForUserApplicationBySql(UniversityFilterForUserApplication filter);
        Task<List<UniversityModel>> GetAllForUserApplicationValidationBySql(UserApplicationModel filter);
    }
}
