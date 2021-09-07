using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class ProfessionalDirectionService : IProfessionalDirectionService
    {
        readonly IUnitOfWork _uow;
        readonly IProfessionalDirectionRepository _proDirectionRepo;
        readonly IMapper _mapper;

        public ProfessionalDirectionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _proDirectionRepo = uow.ProfessionalDirectionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProfessionalDirectionModel>> GetAllAsync()
        {
            var daos = await _proDirectionRepo.GetAllAsync();

            return _mapper.Map<List<ProfessionalDirection>, IEnumerable<ProfessionalDirectionModel>>(daos);
        }
    }
}
