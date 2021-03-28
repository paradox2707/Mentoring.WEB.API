using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mentoring.WEB.API.Common.DTO;

namespace Mentoring.WEB.API.BLL.Interfaces
{
    public interface IUniversityService
    {
        Task<IEnumerable<UniversityModel>> GetAllAsync();
    }
}
