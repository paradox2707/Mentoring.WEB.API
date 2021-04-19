using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using System.Diagnostics;

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

        public async Task<IEnumerable<UniversityModel>> GetAllWithSpecialitiesAsync()
        {
            var daos = await _universityRepo.GetAllWithSpecialiesAsync();
            var dto = _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);

            return dto;
        }
    }
}
