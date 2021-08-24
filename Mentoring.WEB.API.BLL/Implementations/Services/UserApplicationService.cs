using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.Common.FilterModels;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Filters;
using Mentoring.WEB.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        readonly IUnitOfWork _uow;
        readonly IUserApplicationRepository _applicationRepo;
        readonly IRegionRepository _regionRepo;
        readonly IProfessionalDirectionRepository _proDirectionRepo;
        readonly IMapper _mapper;

        public UserApplicationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _applicationRepo = uow.UserApplicationRepository;
            _regionRepo = uow.RegionRepository;
            _proDirectionRepo = uow.ProfessionalDirectionRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(UserApplicationModel entity)
        {
            var dao = _mapper.Map<UserApplicationModel, UserApplication>(entity);
            foreach (var region in entity.Regions)
            {
                var daoRegion = await _regionRepo.GetByAsync(r => r.Name == region.Name);
                dao.Regions.Add(daoRegion);
            }
            foreach (var proDirection in entity.ProfessionalDirections)
            {
                var daoProDirection = await _proDirectionRepo.GetByAsync(pDir => pDir.Name == proDirection.Name);
                dao.ProfessionalDirections.Add(daoProDirection);
            }
            await _applicationRepo.CreateAsync(dao);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<UserApplicationModel>> GetAllAsync() => 
            _mapper.Map<IEnumerable<UserApplication>, IEnumerable<UserApplicationModel>>(await _applicationRepo.GetAllAsync());

        public async Task<IEnumerable<UserApplicationModel>> GetAllByFilterAsync(UserApplicationFilter filter)
        {
            var daoFilter = _mapper.Map<UserApplicationFilter, UserApplicationFilterInSql>(filter);
            var daos = await _applicationRepo.GetAllBySql(daoFilter);
            return _mapper.Map<List<UserApplication>, IEnumerable<UserApplicationModel>>(daos);
        }
    }
}
