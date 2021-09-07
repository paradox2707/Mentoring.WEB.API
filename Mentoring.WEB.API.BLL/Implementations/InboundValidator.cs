using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations
{
    public class InboundValidator : IInboundValidator
    {
        readonly IUnitOfWork _uow;
        readonly IUniversityRepository _universityRepo;
        readonly IMapper _mapper;

        public InboundValidator(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _universityRepo = uow.UniversityRepository;
            _mapper = mapper;
        }

        public async Task<bool> ValidateUserApplication(UserApplicationModel userApplication)
        {
            var daos = await _universityRepo.GetAllForUserApplicationValidationBySql(userApplication);
            if(daos.Any())
                return true;

            throw new ValidationAppException("Doesn`t have any universities with this combination regions and directions");
        }
    }
}
