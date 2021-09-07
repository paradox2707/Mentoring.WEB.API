using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.FilterModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces.DAL
{
    public interface IUserApplicationRepository
    {
        Task<List<UserApplicationModel>> GetAllAsync();
        Task<List<UserApplicationModel>> GetAllBySql(UserApplicationFilter filter);
        Task CreateAsync(UserApplicationModel entity);
    }
}
