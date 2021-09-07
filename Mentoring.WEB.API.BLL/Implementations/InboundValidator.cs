using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Exceptions;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using System.Linq;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations
{
    public class InboundValidator : IInboundValidator
    {
        readonly IUnitOfWork _uow;
        readonly IUniversityRepository _universityRepo;

        public InboundValidator(IUnitOfWork uow)
        {
            _uow = uow;
            _universityRepo = uow.UniversityRepository;
        }

        public async Task<bool> ValidateUserApplication(UserApplicationModel userApplication)
        {
            var userApplications = await _universityRepo.GetAllForUserApplicationValidationBySql(userApplication);
            if(userApplications.Any())
                return true;

            throw new ValidationAppException("Doesn`t have any universities with this combination regions and directions");
        }
    }
}
