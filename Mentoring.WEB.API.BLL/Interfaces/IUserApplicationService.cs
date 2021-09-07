using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces
{
    public interface IUserApplicationService
    {
        Task CreateAsync(UserApplicationModel entity);
        Task<IEnumerable<UserApplicationModel>> GetAllByFilterAsync(UserApplicationFilter filter);
        Task<IEnumerable<UserApplicationModel>> GetAllAsync();
    }
}
