using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class RegionService: IRegionService
    {
        readonly IUnitOfWork _uow;
        readonly IRegionRepository _regionRepo;

        public RegionService(IUnitOfWork uow)
        {
            _uow = uow;
            _regionRepo = uow.RegionRepository;
        }

        public async Task<IEnumerable<RegionModel>> GetAllAsync()
        {
            return await _regionRepo.GetAllAsync();
        }
    }
}
