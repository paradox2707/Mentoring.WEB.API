using Mentoring.WEB.API.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.FilterModels;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class UniversityService : IUniversityService
    {
        readonly IUnitOfWork _uow;
        readonly IUniversityRepository _universityRepo;

        public UniversityService(IUnitOfWork uow)
        {
            _uow = uow;
            _universityRepo = uow.UniversityRepository;
        }

        public async Task<IEnumerable<UniversityModel>> GetAllForUserApplicationByFilterAsync(UniversityFilterForUserApplication filter)
        {
            return  await _universityRepo.GetAllForUserApplicationBySql(filter);
        }
    }
}
