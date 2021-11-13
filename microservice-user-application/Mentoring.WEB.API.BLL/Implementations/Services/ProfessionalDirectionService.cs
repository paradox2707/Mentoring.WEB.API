using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class ProfessionalDirectionService : IProfessionalDirectionService
    {
        readonly IUnitOfWork _uow;
        readonly IProfessionalDirectionRepository _proDirectionRepo;

        public ProfessionalDirectionService(IUnitOfWork uow)
        {
            _uow = uow;
            _proDirectionRepo = uow.ProfessionalDirectionRepository;
        }

        public async Task<IEnumerable<ProfessionalDirectionModel>> GetAllAsync()
        {
            return await _proDirectionRepo.GetAllAsync();
        }
    }
}
