using Mentoring.WEB.API.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces
{
    public interface ISpecialityService
    {
        Task<IEnumerable<SpecialityModel>> GetAllAsync();
    }
}
