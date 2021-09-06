using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class RegionService: IRegionService
    {
        readonly IUnitOfWork _uow;
        readonly IRegionRepository _regionRepo;
        readonly IMapper _mapper;

        public RegionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _regionRepo = uow.RegionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegionModel>> GetAllAsync()
        {
            var daos = await _regionRepo.GetAllAsync();

            return _mapper.Map<List<Region>, IEnumerable<RegionModel>>(daos);
        }
    }
}
