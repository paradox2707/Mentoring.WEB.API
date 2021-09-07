using Mentoring.WEB.API.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces.DAL
{
    public interface ISpecialityRepository
    {
        Task<List<SpecialityModel>> GetAllAsync();
    }
}
