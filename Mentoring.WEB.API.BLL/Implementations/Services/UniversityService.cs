using Mentoring.WEB.API.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.Common.FilterModels;
using Mentoring.WEB.API.BLL.Interfaces.DAL;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class UniversityService : IUniversityService
    {
        readonly IUnitOfWork _uow;
        readonly IUniversityRepository _universityRepo;
        readonly IMapper _mapper;

        public UniversityService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _universityRepo = uow.UniversityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UniversityModel>> GetAllAsync()
        {
            var daos = await _universityRepo.GetAllAsync();

            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

        public async Task<IEnumerable<UniversityModel>> GetAllByFilterAsync(UniversityFilter filter)
        {
            var daoFilter = _mapper.Map<UniversityFilter, UniversityFilterInSql>(filter);
            var daos = await _universityRepo.GetAllBySql(daoFilter);
            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

        public async Task<IEnumerable<UniversityModel>> GetAllForUserApplicationByFilterAsync(UniversityFilterForUserApplication filter)
        {
            var daoFilter = _mapper.Map<UniversityFilterForUserApplication, UniversityFilterForUserApplicationInSql>(filter);
            var daos = await _universityRepo.GetAllForUserApplicationBySql(daoFilter);
            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

        public async Task<IEnumerable<UniversityModel>> GetAllWithSpecialitiesAsync()
        {
            var daos = await _universityRepo.GetAllWithSpecialiesAsync();

            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }
    }
}
