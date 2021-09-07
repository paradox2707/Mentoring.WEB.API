using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class SpecialityService : ISpecialityService
    {
        readonly IUnitOfWork _uow;
        readonly ISpecialityRepository _specialityRepo;
        readonly IMapper _mapper;

        public SpecialityService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _specialityRepo = uow.SpecialityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SpecialityModel>> GetAllAsync()
        {
            var daos = await _specialityRepo.GetAllAsync();

            return _mapper.Map<List<Speciality>, IEnumerable<SpecialityModel>>(daos);
        }
    }
}
