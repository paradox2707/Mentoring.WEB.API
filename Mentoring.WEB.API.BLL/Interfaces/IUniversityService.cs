using System.Collections.Generic;
using System.Threading.Tasks;
using Mentoring.WEB.API.Common.DTO;

namespace Mentoring.WEB.API.BLL.Interfaces
{
    public interface IUniversityService
    {
        Task<IEnumerable<UniversityModel>> GetAllAsync();
        Task<IEnumerable<UniversityModel>> GetAllWithSpecialitiesAsync();
    }
}
