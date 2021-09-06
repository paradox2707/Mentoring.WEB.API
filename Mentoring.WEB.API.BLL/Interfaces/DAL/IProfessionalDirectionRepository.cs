using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces.DAL
{
    public interface IProfessionalDirectionRepository
    {
        Task<List<ProfessionalDirectionModel>> GetAllAsync();

        Task<ProfessionalDirection> GetByAsync(Expression<Func<ProfessionalDirectionModel, bool>> expression);
    }
}
