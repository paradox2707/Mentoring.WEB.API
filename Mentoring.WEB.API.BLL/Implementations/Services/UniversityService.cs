using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using System.Linq;
using System;
using Mentoring.WEB.API.Common.FilterModels;
using System.Linq.Expressions;
using System.Reflection;
using Mentoring.WEB.API.DAL.Filters;

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

        public async Task<IEnumerable<UniversityModel>> GetAllByFilterAsync(UniversityFilter filter)
        {
            var daoFilter = _mapper.Map<UniversityFilter, UniversityFilterDao>(filter);
            var daos = await _universityRepo.GetAllBySql(daoFilter);
            var daos = await _universityRepo.GetAllAsync();
            daos = GetUniversityByFilter(filter.TrimEnd().ToLower(), daos);
            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

        public async Task<IEnumerable<UniversityModel>> GetAllWithSpecialitiesAsync()
        {
            var daos = await _universityRepo.GetAllWithSpecialiesAsync();

            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }
    }
}
