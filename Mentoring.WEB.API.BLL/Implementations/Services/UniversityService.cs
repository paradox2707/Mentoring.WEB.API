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
using Microsoft.Extensions.Logging;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class UniversityService : IUniversityService
    {
        readonly IUnitOfWork _uow;
        readonly IUniversityRepository _universityRepo;
        readonly IMapper _mapper;
        private readonly ILogger<UniversityService> _logger;

        public UniversityService(IUnitOfWork uow, IMapper mapper, ILogger<UniversityService> logger)
        {
            _uow = uow;
            _universityRepo = uow.UniversityRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<UniversityModel>> GetAllAsync()
        {
            _logger.LogInformation("Information is logged from UniversityService");
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
