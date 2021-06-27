using System.Collections.Generic;
using System.Threading.Tasks;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.Common.FilterModels;

namespace Mentoring.WEB.API.BLL.Interfaces
{
    public interface IUniversityService
    {
        Task<IEnumerable<UniversityModel>> GetAllAsync();
        Task<IEnumerable<UniversityModel>> GetAllWithSpecialitiesAsync();
        Task<IEnumerable<UniversityModel>> GetAllByFilterAsync(UniversityFilter filter);
    }
}
