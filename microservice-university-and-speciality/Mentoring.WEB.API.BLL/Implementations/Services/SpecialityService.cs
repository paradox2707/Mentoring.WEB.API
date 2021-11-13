using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class SpecialityService : ISpecialityService
    {
        readonly IUnitOfWork _uow;
        readonly ISpecialityRepository _specialityRepo;

        public SpecialityService(IUnitOfWork uow)
        {
            _uow = uow;
            _specialityRepo = uow.SpecialityRepository;
        }

        public async Task<IEnumerable<SpecialityModel>> GetAllAsync()
        {
            return await _specialityRepo.GetAllAsync();  
        }
    }
}
