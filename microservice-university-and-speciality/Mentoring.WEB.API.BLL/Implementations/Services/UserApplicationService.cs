using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.FilterModels;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        readonly IUnitOfWork _uow;
        readonly IUserApplicationRepository _applicationRepo;
        readonly IRegionRepository _regionRepo;
        readonly IProfessionalDirectionRepository _proDirectionRepo;

        public UserApplicationService(IUnitOfWork uow)
        {
            _uow = uow;
            _applicationRepo = uow.UserApplicationRepository;
            _regionRepo = uow.RegionRepository;
            _proDirectionRepo = uow.ProfessionalDirectionRepository;
        }

        public async Task CreateAsync(UserApplicationModel entity)
        {
            await _applicationRepo.CreateAsync(entity);
        }

        public async Task<IEnumerable<UserApplicationModel>> GetAllAsync() => 
            await _applicationRepo.GetAllAsync();

        public async Task<IEnumerable<UserApplicationModel>> GetAllByFilterAsync(UserApplicationFilter filter)
        {
            
            return await _applicationRepo.GetAllBySql(filter);
            
        }
    }
}
