using Mentoring.WEB.API.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces
{
    public interface IProfessionalDirectionService
    {
        Task<IEnumerable<ProfessionalDirectionModel>> GetAllAsync();
    }
}
