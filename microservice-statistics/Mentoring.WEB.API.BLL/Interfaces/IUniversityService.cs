using System.Collections.Generic;
using System.Threading.Tasks;
using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.FilterModels;

namespace Mentoring.WEB.API.BLL.Interfaces
{
    public interface IUniversityService
    {
        Task<IEnumerable<UniversityModel>> GetAllAsync();
        Task<IEnumerable<UniversityModel>> GetAllWithSpecialitiesAsync();
        Task<IEnumerable<UniversityModel>> GetAllByFilterAsync(UniversityFilter filter);
        Task<IEnumerable<UniversityModel>> GetAllForUserApplicationByFilterAsync(UniversityFilterForUserApplication filter);
    }
}
