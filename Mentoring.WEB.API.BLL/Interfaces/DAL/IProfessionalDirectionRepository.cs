using Mentoring.WEB.API.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces.DAL
{
    public interface IProfessionalDirectionRepository
    {
        Task<List<ProfessionalDirectionModel>> GetAllAsync();
    }
}
