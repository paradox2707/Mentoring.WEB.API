using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces.DAL
{
    public interface ISpecialityRepository
    {
        Task<List<SpecialityModel>> GetAllAsync();
    }
}
